using Medic.App.Controllers.Base;
using Medic.App.Models.InClinicProcedures;
using Medic.AppModels.InClinicProcedures;
using Medic.Cache.Contacts;
using Medic.Logs.Contracts;
using Medic.Logs.Models;
using Medic.Resources;
using Medic.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Medic.App.Controllers
{
    [Authorize]
    public class InClinicProcedureController : MedicBaseController
    {
        private readonly IInClinicProcedureService InClinicProcedureService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly ICacheable MedicCache;
        private readonly IMedicLoggerService MedicLoggerService;

        public InClinicProcedureController(
            IInClinicProcedureService inClinicProcedureService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
        {
            InClinicProcedureService = inClinicProcedureService ?? throw new ArgumentNullException(nameof(inClinicProcedureService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(medicDataLocalization));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> InClinicProcedure(int id)
        {
            try
            {
                InClinicProcedureViewModel model;
                string error = default;
                
                if (id < 0)
                {
                    model = default;
                    error = MedicDataLocalization.Get("InvalidId");
                }
                else
                {
                    string key = $"{nameof(InClinicProcedureViewModel)} - {id}";

                    if (!MedicCache.TryGetValue(key, out model))
                    {
                        model = await InClinicProcedureService.GetInClinicProcedureAsync(id);

                        MedicCache.Set(key, model);
                    }
                }

                return View(new InClinicProcedurePageInClinicProcedureModel()
                {
                    Title = MedicDataLocalization.Get("InClinicProcedure"),
                    Description = MedicDataLocalization.Get("InClinicProcedure"),
                    Keywords = MedicDataLocalization.Get("InClinicProcedureSummary"),
                    InClinicProcedureViewModel = model,
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