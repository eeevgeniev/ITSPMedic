using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Medic.App.Controllers.Base;
using Medic.App.Models.DispObservations;
using Medic.AppModels.DispObservations;
using Medic.Cache.Contacts;
using Medic.Logs.Contracts;
using Medic.Logs.Models;
using Medic.Resources;
using Medic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Medic.App.Controllers
{
    public class DispObservationController : MedicBaseController
    {
        private readonly IDispObservationService DispObservationService;
        private readonly IPatientService PatientService;
        private readonly IHealthRegionService HealthRegionService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly ICacheable MedicCache;
        private readonly IMedicLoggerService MedicLoggerService;

        public DispObservationController(IDispObservationService dispObservationService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
        {
            DispObservationService = dispObservationService ?? throw new ArgumentNullException(nameof(dispObservationService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            HealthRegionService = healthRegionService ?? throw new ArgumentNullException(nameof(healthRegionService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(MedicBaseController));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
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

                    if (!MedicCache.TryGetValue(key, out model))
                    {
                        model = await DispObservationService.GetDispObservationAsync(id);

                        MedicCache.Set(key, model);
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
                Task _ = MedicLoggerService.SaveAsync(new Log()
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