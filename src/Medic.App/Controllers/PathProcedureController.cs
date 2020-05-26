using Medic.App.Controllers.Base;
using Medic.App.Models.PathProcedures;
using Medic.AppModels.PathProcedures;
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
    public class PathProcedureController : MedicBaseController
    {
        private readonly IPathProcedureService PathProcedureService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly ICacheable MedicCache;
        private readonly IMedicLoggerService MedicLoggerService;

        public PathProcedureController(IPathProcedureService pathProcedureService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
        {
            PathProcedureService = pathProcedureService ?? throw new ArgumentNullException(nameof(pathProcedureService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(medicDataLocalization));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> PathProcedure(int id)
        {
            try
            {
                PathProcedureViewModel model;
                string error = default;
                
                if (id < 0)
                {
                    model = default;
                    error = MedicDataLocalization.Get("InvalidId");
                }
                else
                {
                    string key = $"{nameof(PathProcedureViewModel)} - {id}";

                    if (!MedicCache.TryGetValue(key, out model))
                    {
                        model = await PathProcedureService.GetPathProcedureByIdAsync(id);

                        MedicCache.Set(key, model);
                    }
                }
                
                return View(new PathProcedurePagePathProcedureModel()
                {
                    Title = MedicDataLocalization.Get("PathProcedure"),
                    Description = MedicDataLocalization.Get("PathProcedure"),
                    Keywords = MedicDataLocalization.Get("PathProcedureSummary"),
                    PathProcedureViewModel = model,
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