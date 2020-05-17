using Medic.App.Controllers.Base;
using Medic.App.Models.PlannedProcedures;
using Medic.AppModels.PlannedProcedures;
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
    public class PlannedProcedureController : MedicBaseController
    {
        private readonly IPlannedProcedureService PlannedProcedureService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly ICacheable MedicCache;
        private readonly IMedicLoggerService MedicLoggerService;

        public PlannedProcedureController(IPlannedProcedureService plannedProcedureService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
        {
            PlannedProcedureService = plannedProcedureService ?? throw new ArgumentNullException(nameof(plannedProcedureService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(MedicBaseController));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
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

                    if (!MedicCache.TryGetValue(key, out model))
                    {
                        model = await PlannedProcedureService.GetPlannedProcedureAsync(id);

                        MedicCache.Set(key, model);
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