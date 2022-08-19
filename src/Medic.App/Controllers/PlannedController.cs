﻿using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.Plannings;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Plannings;
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
    public class PlannedController : LookupsBaseController
    {
        private readonly IPlannedService PlannedService;
        private readonly IMedicLoggerService MedicLoggerService;
        private readonly IToEHRConverter ToEHRConverter;
        private readonly IFormattableFactory FormattableFactory;

        public PlannedController(IPlannedService plannedService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService,
            IToEHRConverter toEHRConverter,
            IFormattableFactory formattableFactory)
            : base (patientService, healthRegionService, medicCache, medicDataLocalization)
        {
            PlannedService = plannedService ?? throw new ArgumentNullException(nameof(plannedService));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
            ToEHRConverter = toEHRConverter ?? throw new ArgumentNullException(nameof(toEHRConverter));
            FormattableFactory = formattableFactory ?? throw new ArgumentNullException(nameof(formattableFactory));
        }

        public async Task<IActionResult> Index(PlannedSearch search, int page = 1)
        {
            try
            {
                PlannedWhereBuilder plannedWhereBuilder = new PlannedWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                
                List<PlannedPreviewViewModel> plannings = await GetPage(search, plannedWhereBuilder, searchParams, page);

                string plannedCountKey = $"{MedicConstants.Planned} - {searchParams}";

                if (!base.MedicCache.TryGetValue(plannedCountKey, out int planningsCount))
                {
                    planningsCount = await PlannedService
                        .GetPlanningsCountAsync(plannedWhereBuilder);

                    base.MedicCache.Set(plannedCountKey, planningsCount);
                }

                List<SexOption> sexOptions = base.GetDefaultSexes();
                sexOptions.AddRange(await base.GetSexesAsync());

                List<HealthRegionOption> healthRegions = base.GetDefaultHealthRegions();
                healthRegions.AddRange(await base.GetHealthRegionsAsync());

                return View(new PlannedPageIndexModel()
                {
                    Plannings = plannings,
                    Title = MedicDataLocalization.Get(MedicDataLocalization.Plannings),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.Plannings),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.PlanningsSummary),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages((int)search.Length, planningsCount),
                    TotalResults = planningsCount,
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

        public async Task<IActionResult> Planned(int id)
        {
            try
            {
                PlannedViewModel model;
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

                return View(new PlannedPagePlannedModel()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.Planned),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.Planned),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.PlannedSummary),
                    Planned = model,
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
                    PlannedViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    EhrExtract ehrExtractModel = ToEHRConverter.Convert(model, nameof(PlannedViewModel), MedicConstants.ItupMedic);

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
                    PlannedViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    EhrExtract ehrExtractModel = ToEHRConverter.Convert(model, nameof(PlannedViewModel), MedicConstants.ItupMedic);

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

        public async Task<IActionResult> Excel(PlannedSearch search)
        {
            try
            {
                PlannedWhereBuilder plannedWhereBuilder = new PlannedWhereBuilder(search);

                List<PlannedPreviewViewModel> plannings = 
                    await PlannedService.GetPlanningsAsync(plannedWhereBuilder, new PlannedHelperBuilder(default), 0);

                if (plannings == default)
                {
                    return BadRequest();
                }

                return await base.FormatModel<PlannedPreviewViewModel>(plannings, MedicDataLocalization.Plannings, FormattableFactory);
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

        private async Task<PlannedViewModel> GetModelById(int id)
        {
            PlannedViewModel model;

            string key = $"{nameof(PlannedViewModel)} - {id}";

            if (!base.MedicCache.TryGetValue(key, out model))
            {
                model = await PlannedService.GetPlannedAsync(id);

                base.MedicCache.Set(key, model);
            }

            return model;
        }

        private async Task<List<PlannedPreviewViewModel>> GetPage(PlannedSearch search, PlannedWhereBuilder plannedWhereBuilder, string searchParams, int page)
        {
            int pageLength = (int)search.Length;
            int startIndex = base.GetStartIndex(pageLength, page);

            string plannedKey = $"{nameof(PlannedPreviewViewModel)} - {startIndex} - {searchParams}";

            if (!base.MedicCache.TryGetValue(plannedKey, out List<PlannedPreviewViewModel> plannings))
            {
                PlannedHelperBuilder helperBuilder = new PlannedHelperBuilder(search);

                plannings = await PlannedService.GetPlanningsAsync(plannedWhereBuilder, helperBuilder, startIndex);

                base.MedicCache.Set(plannedKey, plannings);
            }

            return plannings;
        }
    }
}