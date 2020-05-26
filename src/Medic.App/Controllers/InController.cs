using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.Ins;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Ins;
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
    public class InController : MedicBaseController
    {
        private readonly IInService InService;
        private readonly IPatientService PatientService;
        private readonly IHealthRegionService HealthRegionService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly ICacheable MedicCache;
        private readonly IMedicLoggerService MedicLoggerService;

        public InController(IInService inService, 
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
        {
            InService = inService ?? throw new ArgumentNullException(nameof(inService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            HealthRegionService = healthRegionService ?? throw new ArgumentNullException(nameof(healthRegionService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(MedicBaseController));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        [HttpGet]
        public async Task<IActionResult> Index(InsSearch search, int page = 1)
        {
            try
            {
                int pageLength = (int)search.Length;
                int startIndex = page > 0 ? (page - 1) * pageLength : 0;
                InWhereBuilder inWhereBuilder = new InWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                string insKey = $"{nameof(InPreviewViewModel)} - {startIndex} - {searchParams}";
                string insCountKey = $"{MedicConstants.InsCount} - {searchParams}";
                
                List<SexOption> sexOptions = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };
                List<HealthRegionOption> healthRegions = new List<HealthRegionOption>() { new HealthRegionOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };

                if (!MedicCache.TryGetValue(insKey, out List<InPreviewViewModel> ins))
                {
                    InHelperBuilder helperBuilder = new InHelperBuilder(search);

                    ins = await InService.GetInsAsync(inWhereBuilder, helperBuilder, startIndex);

                    MedicCache.Set(insKey, ins);
                }

                if (!MedicCache.TryGetValue(insCountKey, out int insCount))
                {
                    insCount = await InService.GetInsCountAsync(inWhereBuilder);

                    MedicCache.Set(insCountKey, insCount);
                }

                if (!MedicCache.TryGetValue(MedicConstants.SexKeyName, out List<SexOption> sexes))
                {
                    sexes = await PatientService.GetSexOptionsAsync();

                    MedicCache.Set(MedicConstants.SexKeyName, sexes);
                }

                sexOptions.AddRange(sexes);

                if (!MedicCache.TryGetValue(MedicConstants.HealthRegionsKeyName, out List<HealthRegionOption> regions))
                {
                    regions = await HealthRegionService.GetHealthRegionsAsync();

                    MedicCache.Set(MedicConstants.HealthRegionsKeyName, regions);
                }

                healthRegions.AddRange(regions);

                return View(new InPageIndexModel()
                {
                    Ins = ins,
                    Title = MedicDataLocalization.Get("InsView"),
                    Description = MedicDataLocalization.Get("InsView"),
                    Keywords = MedicDataLocalization.Get("InsSummary"),
                    Search = search,
                    CurrentPage = page,
                    TotalCount = insCount,
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

                throw;
            }
        }

        public async Task<IActionResult> In(int id)
        {
            try
            {
                InViewModel model;
                string error = default;

                if (id < 1)
                {
                    model = default;
                    error = MedicDataLocalization.Get("InvalidId");
                }
                else
                {
                    string key = $"{nameof(InViewModel)} - {id}";

                    if (!MedicCache.TryGetValue(key, out model))
                    {
                        model = await InService.GetInAsync(id);

                        MedicCache.Set(key, model);
                    }

                    return View(new InPageInModel()
                    {
                        Title = MedicDataLocalization.Get("InView"),
                        Description = MedicDataLocalization.Get("InView"),
                        Keywords = MedicDataLocalization.Get("InSummary"),
                        InViewModel = model
                    });
                }

                return RedirectToAction(nameof(InController.Index), GetControllerName(nameof(InController)));
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