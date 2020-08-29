using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.PathProcedures;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.PathProcedures;
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
    public class PathProcedureController : LookupsBaseController
    {
        private readonly IPathProcedureService PathProcedureService;
        private readonly IClinicUsedDrugsService ClinicUsedDrugsService;
        private readonly IMedicLoggerService MedicLoggerService;
        private readonly IToEHRConverter ToEHRConverter;
        private readonly IFormattableFactory FormattableFactory;

        public PathProcedureController(IPathProcedureService pathProcedureService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            IClinicUsedDrugsService clinicUsedDrugsService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService,
            IToEHRConverter toEHRConverter,
            IFormattableFactory formattableFactory)
            : base (patientService, healthRegionService, medicCache, medicDataLocalization)
        {
            PathProcedureService = pathProcedureService ?? throw new ArgumentNullException(nameof(pathProcedureService));
            ClinicUsedDrugsService = clinicUsedDrugsService ?? throw new ArgumentNullException(nameof(clinicUsedDrugsService));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
            ToEHRConverter = toEHRConverter ?? throw new ArgumentNullException(nameof(toEHRConverter));
            FormattableFactory = formattableFactory ?? throw new ArgumentNullException(nameof(formattableFactory));
        }

        public async Task<IActionResult> Index(PathProcedureSearch search, int page = 1)
        {
            try
            {
                PathProcedureWhereBuilder pathProcedureWhereBuilder = new PathProcedureWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                
                List<PathProcedurePreviewViewModel> pathProcedures = await GetPage(search, pathProcedureWhereBuilder, searchParams, page);

                string pathProceduresCountKey = $"{MedicConstants.PathProcedures} - {searchParams}";

                if (!base.MedicCache.TryGetValue(pathProceduresCountKey, out int pathProceduresCount))
                {
                    pathProceduresCount = await PathProcedureService
                        .GetPathProceduresCountAsync(pathProcedureWhereBuilder);

                    base.MedicCache.Set(pathProceduresCountKey, pathProceduresCount);
                }

                List<SexOption> sexOptions = base.GetDefaultSexes();
                sexOptions.AddRange(await base.GetSexesAsync());

                List<HealthRegionOption> healthRegions = base.GetDefaultHealthRegions();
                healthRegions.AddRange(await base.GetHealthRegionsAsync());

                if (!base.MedicCache.TryGetValue(MedicConstants.ClinicUsedDrugsCode, out List<string> usedDrugs))
                {
                    usedDrugs = await ClinicUsedDrugsService.GetDrugCodesAsync();
                    usedDrugs.Sort((x, y) => x.CompareTo(y));

                    base.MedicCache.Set(MedicConstants.ClinicUsedDrugsCode, usedDrugs);
                }

                List<string> usedDrugCodes = new List<string>() { default };

                usedDrugCodes.AddRange(usedDrugs);

                return View(new PathProcedurePageIndexModel()
                {
                    PathProcedures = pathProcedures,
                    Title = MedicDataLocalization.Get(MedicDataLocalization.PathProcedures),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.PathProcedures),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.PathProceduresSummary),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages((int)search.Length, pathProceduresCount),
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
                
                if (id < 1)
                {
                    model = default;
                    error = MedicDataLocalization.Get(MedicDataLocalization.InvalidId);
                }
                else
                {
                    model = await GetModelById(id);
                }
                
                return View(new PathProcedurePagePathProcedureModel()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.PathProcedure),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.PathProcedure),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.PathProcedureSummary),
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
                    PathProcedureViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    EhrExtract ehrExtractModel = ToEHRConverter.Convert(model, nameof(PathProcedureViewModel), MedicConstants.ItupMedic);

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
                    PathProcedureViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    EhrExtract ehrExtractModel = ToEHRConverter.Convert(model, nameof(PathProcedureViewModel), MedicConstants.ItupMedic);

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

        public async Task<IActionResult> Excel(PathProcedureSearch search, int page = 1)
        {
            try
            {
                PathProcedureWhereBuilder pathProcedureWhereBuilder = new PathProcedureWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;

                List<PathProcedurePreviewViewModel> pathProcedures = await GetPage(search, pathProcedureWhereBuilder, searchParams, page);

                if (pathProcedures == default)
                {
                    return BadRequest();
                }

                return await base.FormatModel<PathProcedurePreviewViewModel>(pathProcedures, MedicDataLocalization.PathProcedures, FormattableFactory);
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

        private async Task<PathProcedureViewModel> GetModelById(int id)
        {
            PathProcedureViewModel model;

            string key = $"{nameof(PathProcedureViewModel)} - {id}";

            if (!base.MedicCache.TryGetValue(key, out model))
            {
                model = await PathProcedureService.GetPathProcedureByIdAsync(id);

                base.MedicCache.Set(key, model);
            }

            return model;
        }

        private async Task<List<PathProcedurePreviewViewModel>> GetPage(PathProcedureSearch search, PathProcedureWhereBuilder pathProcedureWhereBuilder, string searchParams, int page)
        {
            int pageLength = (int)search.Length;
            int startIndex = base.GetStartIndex(pageLength, page);

            string pathProceduresKey = $"{nameof(PathProcedurePreviewViewModel)} - {startIndex} - {searchParams}";

            if (!base.MedicCache.TryGetValue(pathProceduresKey, out List<PathProcedurePreviewViewModel> pathProcedures))
            {
                PathProcedureHelperBuilder helperBuilder = new PathProcedureHelperBuilder(search);

                pathProcedures = await PathProcedureService
                    .GetPathProceduresAsync(pathProcedureWhereBuilder, helperBuilder, startIndex);

                base.MedicCache.Set(pathProceduresKey, pathProcedures);
            }

            return pathProcedures;
        }
    }
}