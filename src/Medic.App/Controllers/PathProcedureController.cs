using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.PathProcedures;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.PathProcedures;
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
using System.Linq;
using System.Threading.Tasks;

namespace Medic.App.Controllers
{
    [Authorize]
    public class PathProcedureController : LookupsBaseController
    {
        private readonly IPathProcedureService PathProcedureService;
        private readonly IClinicUsedDrugsService ClinicUsedDrugsService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly IMedicLoggerService MedicLoggerService;

        public PathProcedureController(IPathProcedureService pathProcedureService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            IClinicUsedDrugsService clinicUsedDrugsService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
            : base (patientService, healthRegionService, medicCache)
        {
            PathProcedureService = pathProcedureService ?? throw new ArgumentNullException(nameof(pathProcedureService));
            ClinicUsedDrugsService = clinicUsedDrugsService ?? throw new ArgumentNullException(nameof(clinicUsedDrugsService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(medicDataLocalization));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> Index(PathProcedureSearch search, int page = 1)
        {
            try
            {
                int pageLength = (int)search.Length;
                int startIndex = base.GetStartIndex(pageLength, page);
                PathProcedureWhereBuilder pathProcedureWhereBuilder = new PathProcedureWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                string pathProceduresKey = $"{nameof(PathProcedurePreviewViewModel)} - {startIndex} - {searchParams}";
                string pathProceduresCountKey = $"{MedicConstants.PathProcedures} - {searchParams}";

                List<SexOption> sexOptions = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };
                List<HealthRegionOption> healthRegions = new List<HealthRegionOption>() { new HealthRegionOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };
                List<string> usedDrugCodes = new List<string>() { default };

                if (!base.MedicCache.TryGetValue(pathProceduresKey, out List<PathProcedurePreviewViewModel> pathProcedures))
                {
                    PathProcedureHelperBuilder helperBuilder = new PathProcedureHelperBuilder(search);

                    pathProcedures = await PathProcedureService
                        .GetPathProceduresAsync(pathProcedureWhereBuilder, helperBuilder, startIndex);

                    base.MedicCache.Set(pathProceduresKey, pathProcedures);
                }

                if (!base.MedicCache.TryGetValue(pathProceduresCountKey, out int pathProceduresCount))
                {
                    pathProceduresCount = await PathProcedureService
                        .GetPathProceduresCountAsync(pathProcedureWhereBuilder);

                    base.MedicCache.Set(pathProceduresCountKey, pathProceduresCount);
                }

                sexOptions.AddRange(await base.GetSexes());

                healthRegions.AddRange(await base.GetHelathRegions());

                if (!base.MedicCache.TryGetValue(MedicConstants.ClinicUsedDrugsCode, out List<string> usedDrugs))
                {
                    usedDrugs = await ClinicUsedDrugsService.GetDrugCodesAsync();
                    usedDrugs.Sort((x, y) => x.CompareTo(y));

                    base.MedicCache.Set(MedicConstants.ClinicUsedDrugsCode, usedDrugs);
                }

                usedDrugCodes.AddRange(usedDrugs);

                return View(new PathProcedurePageIndexModel()
                {
                    PathProcedures = pathProcedures,
                    Title = MedicDataLocalization.Get("PathProcedures"),
                    Description = MedicDataLocalization.Get("PathProcedures"),
                    Keywords = MedicDataLocalization.Get("PathProceduresSummary"),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages(pageLength, pathProceduresCount),
                    TotalResults = pathProceduresCount,
                    Sexes = sexOptions,
                    HealthRegions = healthRegions,
                    UsedDrugCodes = usedDrugCodes
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

                    if (!base.MedicCache.TryGetValue(key, out model))
                    {
                        model = await PathProcedureService.GetPathProcedureByIdAsync(id);

                        base.MedicCache.Set(key, model);
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