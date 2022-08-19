using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.Ins;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Ins;
using Medic.AppModels.Sexes;
using Medic.Cache.Contacts;
using Medic.EHR.Extracts;
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
    public class InController : LookupsBaseController
    {
        private readonly IInService InService;
        private readonly IMedicLoggerService MedicLoggerService;
        private readonly IToEHRConverter ToEHRConverter;
        private readonly IFormattableFactory FormattableFactory;

        public InController(IInService inService, 
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService,
            IToEHRConverter toEHRConverter,
            IFormattableFactory formattableFactory)
            : base (patientService, healthRegionService, medicCache, medicDataLocalization)
        {
            InService = inService ?? throw new ArgumentNullException(nameof(inService));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
            ToEHRConverter = toEHRConverter ?? throw new ArgumentNullException(nameof(toEHRConverter));
            FormattableFactory = formattableFactory ?? throw new ArgumentNullException(nameof(formattableFactory));
        }

        [HttpGet]
        public async Task<IActionResult> Index(InsSearch search, int page = 1)
        {
            try
            {
                InWhereBuilder inWhereBuilder = new InWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                
                string insCountKey = $"{MedicConstants.InsCount} - {searchParams}";

                List<InPreviewViewModel> ins = await GetPage(search, inWhereBuilder, searchParams, page);

                if (!base.MedicCache.TryGetValue(insCountKey, out int insCount))
                {
                    insCount = await InService.GetInsCountAsync(inWhereBuilder);

                    base.MedicCache.Set(insCountKey, insCount);
                }

                List<SexOption> sexOptions = base.GetDefaultSexes();
                sexOptions.AddRange(await base.GetSexesAsync());

                List<HealthRegionOption> healthRegions = base.GetDefaultHealthRegions();
                healthRegions.AddRange(await base.GetHealthRegionsAsync());

                return View(new InPageIndexModel()
                {
                    Ins = ins,
                    Title = MedicDataLocalization.Get(MedicDataLocalization.InsView),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.InsView),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.InsSummary),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages((int)search.Length, insCount),
                    TotalResults = insCount,
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

                throw;
            }
        }

        public async Task<IActionResult> In(int id)
        {
            try
            {
                InViewModel model;
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

                return View(new InPageInModel()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.InView),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.InView),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.InSummary),
                    InViewModel = model,
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
                    InViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    EhrExtract ehrExtractModel = ToEHRConverter.Convert(model, nameof(InViewModel), MedicConstants.ItupMedic);

                    return await base.FormatModel(ehrExtractModel, FormattableFactory.CreateFormatter(FormatterEnum.XML));
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
                    InViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    EhrExtract ehrExtractModel = ToEHRConverter.Convert(model, nameof(InViewModel), MedicConstants.ItupMedic);

                    return await base.FormatModel(ehrExtractModel, FormattableFactory.CreateFormatter(FormatterEnum.Json));
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

        public async Task<IActionResult> Excel(InsSearch search)
        {
            try
            {
                InWhereBuilder inWhereBuilder = new InWhereBuilder(search);

                List<InPreviewViewModel> ins = await InService.GetInsAsync(inWhereBuilder, new InHelperBuilder(default), 0);

                if (ins == default)
                {
                    return BadRequest();
                }

                return await base.FormatModel<InPreviewViewModel>(ins, MedicDataLocalization.Ins, FormattableFactory);
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

        private async Task<InViewModel> GetModelById(int id)
        {
            InViewModel model;

            string key = $"{nameof(InViewModel)} - {id}";

            if (!base.MedicCache.TryGetValue(key, out model))
            {
                model = await InService.GetInAsync(id);

                base.MedicCache.Set(key, model);
            }

            return model;
        }

        private async Task<List<InPreviewViewModel>> GetPage(InsSearch search, InWhereBuilder inWhereBuilder, string searchParams, int page)
        {
            int pageLength = (int)search.Length;
            int startIndex = base.GetStartIndex(pageLength, page);

            string insKey = $"{nameof(InPreviewViewModel)} - {startIndex} - {searchParams}";

            if (!base.MedicCache.TryGetValue(insKey, out List<InPreviewViewModel> ins))
            {
                InHelperBuilder helperBuilder = new InHelperBuilder(search);

                ins = await InService.GetInsAsync(inWhereBuilder, helperBuilder, startIndex);

                base.MedicCache.Set(insKey, ins);
            }

            return ins;
        }
    }
}