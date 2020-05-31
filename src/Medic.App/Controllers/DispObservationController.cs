using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.DispObservations;
using Medic.AppModels.DispObservations;
using Medic.AppModels.HealthRegions;
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
    public class DispObservationController : LookupsBaseController
    {
        private readonly IDispObservationService DispObservationService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly IMedicLoggerService MedicLoggerService;

        public DispObservationController(IDispObservationService dispObservationService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
            : base (patientService, healthRegionService, medicCache)
        {
            DispObservationService = dispObservationService ?? throw new ArgumentNullException(nameof(dispObservationService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(MedicBaseController));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> Index(DispObservationSearch search, int page = 1)
        {
            try
            {
                int pageLength = (int)search.Length;
                int startIndex = base.GetStartIndex(pageLength, page);
                DispObservationWhereBuilder pathProcedureWhereBuilder = new DispObservationWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                string dispObservationsKey = $"{nameof(DispObservationPreviewViewModel)} - {startIndex} - {searchParams}";
                string dispObservationsCountKey = $"{MedicConstants.DispObservations} - {searchParams}";

                List<SexOption> sexOptions = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };
                List<HealthRegionOption> healthRegions = new List<HealthRegionOption>() { new HealthRegionOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };

                if (!base.MedicCache.TryGetValue(dispObservationsKey, out List<DispObservationPreviewViewModel> dispObservations))
                {
                    DispObservationHelperBuilder helperBuilder = new DispObservationHelperBuilder(search);

                    dispObservations = await DispObservationService
                        .GetDispObservationsAsync(pathProcedureWhereBuilder, helperBuilder, startIndex);

                    base.MedicCache.Set(dispObservationsKey, dispObservations);
                }

                if (!base.MedicCache.TryGetValue(dispObservationsCountKey, out int dispObservationsCount))
                {
                    dispObservationsCount = await DispObservationService
                        .GetDispObservationsCountAsync(pathProcedureWhereBuilder);

                    base.MedicCache.Set(dispObservationsCountKey, dispObservationsCount);
                }

                sexOptions.AddRange(await base.GetSexes());

                healthRegions.AddRange(await base.GetHelathRegions());

                return View(new DispObservationPageIndexModel()
                {
                    DispObservations = dispObservations,
                    Title = MedicDataLocalization.Get("DispObservations"),
                    Description = MedicDataLocalization.Get("DispObservations"),
                    Keywords = MedicDataLocalization.Get("DispObservationsSummary"),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages(pageLength, dispObservationsCount),
                    TotalResults = dispObservationsCount,
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

        public async Task<IActionResult> DispObservation(int id)
        {
            try
            {
                DispObservationViewModel model;
                string error = default;

                if (id < 0)
                {
                    model = default;
                    error = MedicDataLocalization.Get("InvalidId");
                }
                else
                {
                    string key = $"{nameof(DispObservationViewModel)} - {id}";

                    if (!base.MedicCache.TryGetValue(key, out model))
                    {
                        model = await DispObservationService.GetDispObservationAsync(id);

                        base.MedicCache.Set(key, model);
                    }
                }

                return View(new DispObservationPageDispObservationModel()
                {
                    Title = MedicDataLocalization.Get("DispObservation"),
                    Description = MedicDataLocalization.Get("DispObservation"),
                    Keywords = MedicDataLocalization.Get("DispObservationSummary"),
                    DispObservation = model,
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