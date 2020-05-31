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
    public class InController : LookupsBaseController
    {
        private readonly IInService InService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly IMedicLoggerService MedicLoggerService;

        public InController(IInService inService, 
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
            : base (patientService, healthRegionService, medicCache)
        {
            InService = inService ?? throw new ArgumentNullException(nameof(inService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(MedicBaseController));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        [HttpGet]
        public async Task<IActionResult> Index(InsSearch search, int page = 1)
        {
            try
            {
                int pageLength = (int)search.Length;
                int startIndex = base.GetStartIndex(pageLength, page);
                InWhereBuilder inWhereBuilder = new InWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                string insKey = $"{nameof(InPreviewViewModel)} - {startIndex} - {searchParams}";
                string insCountKey = $"{MedicConstants.InsCount} - {searchParams}";
                
                List<SexOption> sexOptions = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };
                List<HealthRegionOption> healthRegions = new List<HealthRegionOption>() { new HealthRegionOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };

                if (!base.MedicCache.TryGetValue(insKey, out List<InPreviewViewModel> ins))
                {
                    InHelperBuilder helperBuilder = new InHelperBuilder(search);

                    ins = await InService.GetInsAsync(inWhereBuilder, helperBuilder, startIndex);

                    base.MedicCache.Set(insKey, ins);
                }

                if (!base.MedicCache.TryGetValue(insCountKey, out int insCount))
                {
                    insCount = await InService.GetInsCountAsync(inWhereBuilder);

                    base.MedicCache.Set(insCountKey, insCount);
                }

                sexOptions.AddRange(await base.GetSexes());

                healthRegions.AddRange(await base.GetHelathRegions());

                return View(new InPageIndexModel()
                {
                    Ins = ins,
                    Title = MedicDataLocalization.Get("InsView"),
                    Description = MedicDataLocalization.Get("InsView"),
                    Keywords = MedicDataLocalization.Get("InsSummary"),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages(pageLength, insCount),
                    TotalResults = insCount,
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

                    if (!base.MedicCache.TryGetValue(key, out model))
                    {
                        model = await InService.GetInAsync(id);

                        base.MedicCache.Set(key, model);
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