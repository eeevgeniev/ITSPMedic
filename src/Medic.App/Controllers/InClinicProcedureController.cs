using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.InClinicProcedures;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.InClinicProcedures;
using Medic.AppModels.Sexes;
using Medic.Cache.Contacts;
using Medic.EHR.RM;
using Medic.Formatters.Contracts;
using Medic.Formatters.Enums;
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
    public class InClinicProcedureController : LookupsBaseController
    {
        private readonly IInClinicProcedureService InClinicProcedureService;
        private readonly IMedicLoggerService MedicLoggerService;
        private readonly IToEHRConverter ToEHRConverter;
        private readonly IFormattableFactory FormattableFactory;

        public InClinicProcedureController(
            IInClinicProcedureService inClinicProcedureService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService,
            IToEHRConverter toEHRConverter,
            IFormattableFactory formattableFactory)
            : base (patientService, healthRegionService, medicCache, medicDataLocalization)
        {
            InClinicProcedureService = inClinicProcedureService ?? throw new ArgumentNullException(nameof(inClinicProcedureService));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
            ToEHRConverter = toEHRConverter ?? throw new ArgumentNullException(nameof(toEHRConverter));
            FormattableFactory = formattableFactory ?? throw new ArgumentNullException(nameof(formattableFactory));
        }

        public async Task<IActionResult> Index(InClinicProcedureSearch search, int page = 1)
        {
            try
            {
                InClinicProcedureWhereBuilder inClinicProcedureWhereBuilder = new InClinicProcedureWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                
                string inclinicProceduresCountKey = $"{MedicConstants.InClinicProcedures} - {searchParams}";

                List<InClinicProcedurePreviewViewModel> inClinicProcedures = await GetPage(search, inClinicProcedureWhereBuilder, searchParams, page);

                if (!base.MedicCache.TryGetValue(inclinicProceduresCountKey, out int inClinicProceduresCount))
                {
                    inClinicProceduresCount = await InClinicProcedureService
                        .GetInClinicProceduresCountAsync(inClinicProcedureWhereBuilder);

                    base.MedicCache.Set(inclinicProceduresCountKey, inClinicProceduresCount);
                }

                List<SexOption> sexOptions = base.GetDefaultSexes();
                sexOptions.AddRange(await base.GetSexesAsync());

                List<HealthRegionOption> healthRegions = base.GetDefaultHealthRegions();
                healthRegions.AddRange(await base.GetHealthRegionsAsync());

                return View(new InClinicProcedurePageIndexModel()
                {
                    InClinicProcedures = inClinicProcedures,
                    Title = MedicDataLocalization.Get(MedicDataLocalization.InClinicProcedures),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.InClinicProcedures),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.InClinicProceduresSummary),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages((int)search.Length, inClinicProceduresCount),
                    TotalResults = inClinicProceduresCount,
                    Sexes = sexOptions,
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

                throw ex;
            }
        }

        public async Task<IActionResult> InClinicProcedure(int id)
        {
            try
            {
                InClinicProcedureViewModel model;
                string error = default;
                
                if (id < 1)
                {
                    model = default;
                    error = MedicDataLocalization.Get(MedicDataLocalization.InvalidId);
                }
                else
                {
                    model = await GetModelById(id);
                }

                return View(new InClinicProcedurePageInClinicProcedureModel()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.InClinicProcedure),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.InClinicProcedure),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.InClinicProcedureSummary),
                    InClinicProcedureViewModel = model,
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
                    InClinicProcedureViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    ReferenceModel referenceModel = ToEHRConverter.Convert(model, nameof(InClinicProcedureViewModel));

                    return await base.FormatModel(referenceModel, FormattableFactory.CreateFormatter(FormatterEnum.XML));
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
                    InClinicProcedureViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    ReferenceModel referenceModel = ToEHRConverter.Convert(model, nameof(InClinicProcedureViewModel));

                    return await base.FormatModel(referenceModel, FormattableFactory.CreateFormatter(FormatterEnum.Json));
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

        public async Task<IActionResult> Excel(InClinicProcedureSearch search, int page = 1)
        {
            try
            {
                InClinicProcedureWhereBuilder inClinicProcedureWhereBuilder = new InClinicProcedureWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;

                List<InClinicProcedurePreviewViewModel> inClinicProcedures = await GetPage(search, inClinicProcedureWhereBuilder, searchParams, page);

                if (inClinicProcedures == default)
                {
                    return BadRequest();
                }

                return await base.FormatModel<InClinicProcedurePreviewViewModel>(inClinicProcedures, MedicDataLocalization.InClinicProcedures, FormattableFactory);
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

        private async Task<InClinicProcedureViewModel> GetModelById(int id)
        {
            InClinicProcedureViewModel model;

            string key = $"{nameof(InClinicProcedureViewModel)} - {id}";

            if (!base.MedicCache.TryGetValue(key, out model))
            {
                model = await InClinicProcedureService.GetInClinicProcedureAsync(id);

                base.MedicCache.Set(key, model);
            }

            return model;
        }

        private async Task<List<InClinicProcedurePreviewViewModel>> GetPage(InClinicProcedureSearch search, InClinicProcedureWhereBuilder inClinicProcedureWhereBuilder, string searchParams, int page)
        {
            int pageLength = (int)search.Length;
            int startIndex = base.GetStartIndex(pageLength, page);

            string inclinicProceduresKey = $"{nameof(InClinicProcedurePreviewViewModel)} - {startIndex} - {searchParams}";

            if (!base.MedicCache.TryGetValue(inclinicProceduresKey, out List<InClinicProcedurePreviewViewModel> inClinicProcedures))
            {
                InClinicProcedureHelperBuilder helperBuilder = new InClinicProcedureHelperBuilder(search);

                inClinicProcedures = await InClinicProcedureService
                    .GetInClinicProceduresAsync(inClinicProcedureWhereBuilder, helperBuilder, startIndex);

                base.MedicCache.Set(inclinicProceduresKey, inClinicProcedures);
            }

            return inClinicProcedures;
        }
    }
}