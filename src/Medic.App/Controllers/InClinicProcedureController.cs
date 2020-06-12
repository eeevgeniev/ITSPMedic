using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.InClinicProcedures;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.InClinicProcedures;
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
    public class InClinicProcedureController : LookupsBaseController
    {
        private readonly IInClinicProcedureService InClinicProcedureService;
        private readonly IMedicLoggerService MedicLoggerService;

        public InClinicProcedureController(
            IInClinicProcedureService inClinicProcedureService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
            : base (patientService, healthRegionService, medicCache, medicDataLocalization)
        {
            InClinicProcedureService = inClinicProcedureService ?? throw new ArgumentNullException(nameof(inClinicProcedureService));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> Index(InClinicProcedureSearch search, int page = 1)
        {
            try
            {
                int pageLength = (int)search.Length;
                int startIndex = base.GetStartIndex(pageLength, page);
                InClinicProcedureWhereBuilder inClinicProcedureWhereBuilder = new InClinicProcedureWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                string inclinicProceduresKey = $"{nameof(InClinicProcedurePreviewViewModel)} - {startIndex} - {searchParams}";
                string inclinicProceduresCountKey = $"{MedicConstants.InClinicProcedures} - {searchParams}";

                if (!base.MedicCache.TryGetValue(inclinicProceduresKey, out List<InClinicProcedurePreviewViewModel> inClinicProcedures))
                {
                    InClinicProcedureHelperBuilder helperBuilder = new InClinicProcedureHelperBuilder(search);

                    inClinicProcedures = await InClinicProcedureService
                        .GetInClinicProceduresAsync(inClinicProcedureWhereBuilder, helperBuilder, startIndex);

                    base.MedicCache.Set(inclinicProceduresKey, inClinicProcedures);
                }

                if (!base.MedicCache.TryGetValue(inclinicProceduresCountKey, out int inClinicProceduresCount))
                {
                    inClinicProceduresCount = await InClinicProcedureService
                        .GetInClinicProceduresCountAsync(inClinicProcedureWhereBuilder);

                    base.MedicCache.Set(inclinicProceduresCountKey, inClinicProceduresCount);
                }

                List<SexOption> sexOptions = base.GetDefaultSexes();
                sexOptions.AddRange(await base.GetSexesAsync());

                List<HealthRegionOption> healthRegions = base.GetDefaultHealthRegions();
                healthRegions.AddRange(await base.GetHealthRegionsAsync());

                return View(new InClinicProcedurePageIndexModel()
                {
                    InClinicProcedures = inClinicProcedures,
                    Title = MedicDataLocalization.Get("InClinicProcedures"),
                    Description = MedicDataLocalization.Get("InClinicProcedures"),
                    Keywords = MedicDataLocalization.Get("InClinicProceduresSummary"),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages(pageLength, inClinicProceduresCount),
                    TotalResults = inClinicProceduresCount,
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

                    if (!base.MedicCache.TryGetValue(key, out model))
                    {
                        model = await InClinicProcedureService.GetInClinicProcedureAsync(id);

                        base.MedicCache.Set(key, model);
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