using Medic.App.Controllers.Base;
using Medic.App.Models.CommissionAprs;
using Medic.AppModels.CommissionAprs;
using Medic.Cache.Contacts;
using Medic.Logs.Contracts;
using Medic.Logs.Models;
using Medic.Resources;
using Medic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Medic.App.Controllers
{
    public class CommissionAprController : MedicBaseController
    {
        private readonly ICommissionAprService CommissionAprService;
        private readonly IPatientService PatientService;
        private readonly IHealthRegionService HealthRegionService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly ICacheable MedicCache;
        private readonly IMedicLoggerService MedicLoggerService;

        public CommissionAprController(ICommissionAprService commissionAprService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
        {
            CommissionAprService = commissionAprService ?? throw new ArgumentNullException(nameof(commissionAprService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            HealthRegionService = healthRegionService ?? throw new ArgumentNullException(nameof(healthRegionService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(MedicBaseController));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> CommissionApr(int id)
        {
            try
            {
                CommissionAprViewModel model;
                string error = default;

                if (id < 0)
                {
                    model = default;
                    error = MedicDataLocalization.Get("InvalidId");
                }
                else
                {
                    string key = $"{nameof(CommissionAprViewModel)} - {id}";

                    if (!MedicCache.TryGetValue(key, out model))
                    {
                        model = await CommissionAprService.GetCommissionAprAsync(id);

                        MedicCache.Set(key, model);
                    }
                }

                return View(new CommissionAprPageCommissionAprModel()
                {
                    Title = MedicDataLocalization.Get("CommissionApr"),
                    Description = MedicDataLocalization.Get("CommissionApr"),
                    Keywords = MedicDataLocalization.Get("CommissionAprSummary"),
                    CommissionApr = model,
                    Error = error
                });
            }
            catch (Exception ex)
            {
                await MedicLoggerService.SaveAsync(new Log()
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