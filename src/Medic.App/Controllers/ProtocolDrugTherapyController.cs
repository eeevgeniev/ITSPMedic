using Medic.App.Controllers.Base;
using Medic.App.Models.ProtocolDrugTherapy;
using Medic.AppModels.ProtocolDrugTherapies;
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
    public class ProtocolDrugTherapyController : MedicBaseController
    {
        private readonly IProtocolDrugTherapyService ProtocolDrugTherapyService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly ICacheable MedicCache;
        private readonly IMedicLoggerService MedicLoggerService;

        public ProtocolDrugTherapyController(
            IProtocolDrugTherapyService protocolDrugTherapyService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
        {
            ProtocolDrugTherapyService = protocolDrugTherapyService ?? throw new ArgumentNullException(nameof(protocolDrugTherapyService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(medicDataLocalization));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> ProtocolDrugTherapy(int id)
        {
            try
            {
                ProtocolDrugTherapyViewModel model;
                string error = default;

                if (id < 0)
                {
                    model = default;
                    error = MedicDataLocalization.Get("InvalidId");
                }
                else
                {
                    string key = $"{nameof(ProtocolDrugTherapyViewModel)} - {id}";

                    if (!MedicCache.TryGetValue(key, out model))
                    {
                        model = await ProtocolDrugTherapyService.GetProtocolDrugTherapyAsync(id);

                        MedicCache.Set(key, model);
                    }
                }

                return View(new ProtocolDrugTherapyPageProtocolDrugTherapyModel()
                {
                    Title = MedicDataLocalization.Get("PathProcedure"),
                    Description = MedicDataLocalization.Get("PathProcedure"),
                    Keywords = MedicDataLocalization.Get("PathProcedureSummary"),
                    ProtocolDrugTherapy = model,
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