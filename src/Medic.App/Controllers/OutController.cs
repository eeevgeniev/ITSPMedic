using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.Outs;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Outs;
using Medic.AppModels.Sexes;
using Medic.AppModels.UsedDrugs;
using Medic.Cache.Contacts;
using Medic.EHR.RM;
using Medic.Formatters.Contracts;
using Medic.Logs.Contracts;
using Medic.Logs.Models;
using Medic.ModelToEHR.Contracts;
using Medic.Resources;
using Medic.Services.Contracts;
using Medic.Services.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.App.Controllers
{
    [Authorize]
    public class OutController : LookupsBaseController
    {
        private readonly IOutService OutService;
        private readonly IUsedDrugService UsedDrugService;
        private readonly IMedicLoggerService MedicLoggerService;
        private readonly IToEHRConverter ToEHRConverter;
        private readonly IFormattableFactory FormattableFactory;

        public OutController(IOutService outService, 
            IPatientService patientService, 
            IUsedDrugService usedDrugService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService,
            IToEHRConverter toEHRConverter,
            IFormattableFactory formattableFactory)
            : base (patientService, healthRegionService, medicCache, medicDataLocalization)
        {
            OutService = outService ?? throw new ArgumentNullException(nameof(outService));
            UsedDrugService = usedDrugService ?? throw new ArgumentNullException(nameof(usedDrugService));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
            ToEHRConverter = toEHRConverter ?? throw new ArgumentNullException(nameof(toEHRConverter));
            FormattableFactory = formattableFactory ?? throw new ArgumentNullException(nameof(formattableFactory));
        }

        public async Task<IActionResult> Index(OutSearch search, int page = 1)
        {
            try
            {
                int pageLength = (int)search.Length;
                int startIndex = base.GetStartIndex(pageLength, page);
                OutWhereBuilder outWhereBuilder = new OutWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                string outsKey = $"{nameof(OutPreviewViewModel)} - {startIndex} - {searchParams}";
                string outsCountKey = $"{MedicConstants.OutsCount} - {searchParams}";
                
                if (!base.MedicCache.TryGetValue(outsKey, out List<OutPreviewViewModel> outs))
                {
                    OutHelperBuilder outHelperBuilder = new OutHelperBuilder(search);

                    outs = await OutService.GetOutsAsync(outWhereBuilder, outHelperBuilder, startIndex);

                    base.MedicCache.Set(outsKey, outs);
                }

                if (!base.MedicCache.TryGetValue(outsCountKey, out int outsCount))
                {
                    outsCount = await OutService.GetOutsCountAsync(outWhereBuilder);

                    base.MedicCache.Set(outsCountKey, outsCount);
                }

                List<SexOption> sexOptions = base.GetDefaultSexes();
                sexOptions.AddRange(await base.GetSexesAsync());

                List<HealthRegionOption> healthRegions = base.GetDefaultHealthRegions();
                healthRegions.AddRange(await base.GetHealthRegionsAsync());

                List<UsedDrugCodeOption> usedDrugs = new List<UsedDrugCodeOption>() { 
                    new UsedDrugCodeOption() { Key = string.Empty, Code = MedicDataLocalization.Get(MedicDataLocalization.NoSelection) } };

                if (!MedicCache.TryGetValue(MedicConstants.UsedDrugs, out List<UsedDrugCodeOption> drugs))
                {
                    drugs = await UsedDrugService.UsedDrugsByCodeAsync();

                    MedicCache.Set(MedicConstants.UsedDrugs, drugs);
                }

                usedDrugs.AddRange(drugs);

                return View(new OutPageIndexModel()
                {
                    Outs = outs,
                    Title = MedicDataLocalization.Get(MedicDataLocalization.OutsView),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.OutsView),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.OutsSummary),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages(pageLength, outsCount),
                    TotalResults = outsCount,
                    Sexes = sexOptions,
                    UsedDrugCodes = usedDrugs,
                    HealthRegions = healthRegions
                });
            }
            catch (Exception ex)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log()
                {
                    Message = ex.Message,
                    InnerExceptionMessage = ex?.InnerException?.Message ?? null,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                    Date = DateTime.Now
                });

                throw;
            }
        }

        public async Task<IActionResult> Out(int id)
        {
            try
            {
                OutViewModel model;
                string error = default;

                if (id < 1)
                {
                    error = MedicDataLocalization.Get(MedicDataLocalization.InvalidId);
                    model = default;
                }
                else
                {
                    model = await GetModelById(id);
                }

                return View(new OutPageOutModel()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.OutView),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.OutView),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.OutSummary),
                    OutViewModel = model,
                    Error = error
                });
            }
            catch (Exception ex)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log()
                {
                    Message = ex.Message,
                    InnerExceptionMessage = ex?.InnerException?.Message ?? null,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                    Date = DateTime.Now
                });

                throw;
            }
        }

        public async Task<IActionResult> Xml(int id)
        {
            try
            {
                if (id < 1)
                {
                    return RedirectToAction(nameof(HomeController.Index), this.GetControllerName(nameof(HomeController)));
                }
                else
                {
                    OutViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    ReferenceModel referenceModel = ToEHRConverter.Convert(model, nameof(OutViewModel));
                    IDataFormattable xmlFormater = FormattableFactory.CreateXMLFormatter();

                    return new ContentResult()
                    {
                        Content = await xmlFormater.FormatObject(referenceModel),
                        ContentType = xmlFormater.MimeType,
                        StatusCode = 200
                    };
                }
            }
            catch (Exception ex)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log()
                {
                    Message = ex.Message,
                    InnerExceptionMessage = ex?.InnerException?.Message ?? null,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                    Date = DateTime.Now
                });

                throw;
            }
        }

        public async Task<IActionResult> Json(int id)
        {
            try
            {
                if (id < 1)
                {
                    return RedirectToAction(nameof(HomeController.Index), this.GetControllerName(nameof(HomeController)));
                }
                else
                {
                    OutViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    ReferenceModel referenceModel = ToEHRConverter.Convert(model, nameof(OutViewModel));
                    IDataFormattable jsonFormater = FormattableFactory.CreateJsonFormatter();

                    return new ContentResult()
                    {
                        Content = await jsonFormater.FormatObject(referenceModel),
                        ContentType = jsonFormater.MimeType,
                        StatusCode = 200
                    };
                }
            }
            catch (Exception ex)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log()
                {
                    Message = ex.Message,
                    InnerExceptionMessage = ex?.InnerException?.Message ?? null,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                    Date = DateTime.Now
                });

                throw;
            }
        }

        private async Task<OutViewModel> GetModelById(int id)
        {
            OutViewModel model;

            string key = $"{nameof(OutViewModel)} - {id}";

            if (!base.MedicCache.TryGetValue(key, out model))
            {
                model = await OutService.GetOutAsyns(id);

                base.MedicCache.Set(key, model);
            }

            return model;
        }
    }
}