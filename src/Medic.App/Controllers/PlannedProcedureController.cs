using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.PlannedProcedures;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.PlannedProcedures;
using Medic.AppModels.Sexes;
using Medic.Cache.Contacts;
using Medic.Logs.Contracts;
using Medic.Logs.Models;
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
    public class PlannedProcedureController : LookupsBaseController
    {
        private readonly IPlannedProcedureService PlannedProcedureService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly IMedicLoggerService MedicLoggerService;

        public PlannedProcedureController(IPlannedProcedureService plannedProcedureService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
            : base (patientService, healthRegionService, medicCache)
        {
            PlannedProcedureService = plannedProcedureService ?? throw new ArgumentNullException(nameof(plannedProcedureService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(MedicBaseController));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> Index(PlannedProcedureSearch search, int page = 1)
        {
            try
            {
                int pageLength = (int)search.Length;
                int startIndex = base.GetStartIndex(pageLength, page);
                PlannedProcedureWhereBuilder pathProcedureWhereBuilder = new PlannedProcedureWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                string plannedProceduresKey = $"{nameof(PlannedProcedurePreviewViewModel)} - {startIndex} - {searchParams}";
                string plannedProceduresCountKey = $"{MedicConstants.PlannedProcedures} - {searchParams}";

                List<SexOption> sexOptions = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };
                List<HealthRegionOption> healthRegions = new List<HealthRegionOption>() { new HealthRegionOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };

                if (!base.MedicCache.TryGetValue(plannedProceduresKey, out List<PlannedProcedurePreviewViewModel> plannedProcedures))
                {
                    PlannedProcedureHelperBuilder helperBuilder = new PlannedProcedureHelperBuilder(search);

                    plannedProcedures = await PlannedProcedureService
                        .GetPlannedProceduresAsync(pathProcedureWhereBuilder, helperBuilder, startIndex);

                    base.MedicCache.Set(plannedProceduresKey, plannedProcedures);
                }

                if (!base.MedicCache.TryGetValue(plannedProceduresCountKey, out int plannedProceduresCount))
                {
                    plannedProceduresCount = await PlannedProcedureService
                        .GetPlannedProceduresCountAsync(pathProcedureWhereBuilder);

                    base.MedicCache.Set(plannedProceduresCountKey, plannedProceduresCount);
                }

                sexOptions.AddRange(await base.GetSexes());

                healthRegions.AddRange(await base.GetHelathRegions());

                return View(new PlannedProcedurePageIndexModel()
                {
                    PlannedProcedures = plannedProcedures,
                    Title = MedicDataLocalization.Get("PlannedProcedures"),
                    Description = MedicDataLocalization.Get("PlannedProcedures"),
                    Keywords = MedicDataLocalization.Get("PlannedProceduresSummary"),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages(pageLength, plannedProceduresCount),
                    TotalResults = plannedProceduresCount,
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

        public async Task<IActionResult> PlannedProcedure(int id)
        {
            try
            {
                PlannedProcedureViewModel model;
                string error = default;

                if (id < 0)
                {
                    model = default;
                    error = MedicDataLocalization.Get("InvalidId");
                }
                else
                {
                    string key = $"{nameof(PlannedProcedureViewModel)} - {id}";

                    if (!base.MedicCache.TryGetValue(key, out model))
                    {
                        model = await PlannedProcedureService.GetPlannedProcedureAsync(id);

                        base.MedicCache.Set(key, model);
                    }
                }

                return View(new PlannedProcedurePagePlannedProcedureModel()
                {
                    Title = MedicDataLocalization.Get("PlannedProcedure"),
                    Description = MedicDataLocalization.Get("PlannedProcedure"),
                    Keywords = MedicDataLocalization.Get("PlannedProcedureSummary"),
                    PlannedProcedure = model,
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
    }
}