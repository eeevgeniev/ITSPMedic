using Medic.App.Controllers.Base;
using Medic.App.Models.Ins;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Ins;
using Medic.AppModels.Sexes;
using Medic.Cache.Contacts;
using Medic.Logs.Contracts;
using Medic.Logs.Models;
using Medic.Resources;
using Medic.Services.Contracts;
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
        public async Task<IActionResult> Index(InsSerach search, int page = 1)
        {
            try
            {
                int startIndex = page > 0 ? (page - 1) * 10 : 0;
                string key = $"{nameof(InPageIndexModel)} - {startIndex} - {search?.ToString() ?? string.Empty}";

                if (!MedicCache.TryGetValue(key, out InPageIndexModel inPageIndexModel))
                {
                    inPageIndexModel = new InPageIndexModel()
                    {
                        Ins = await InService.GetInsAsync(search, startIndex, 10),
                        Title = MedicDataLocalization.Get("InsView"),
                        Description = MedicDataLocalization.Get("InsView"),
                        Keywords = MedicDataLocalization.Get("InsSummary"),
                        Search = search,
                        CurrentPage = page,
                        TotalCount = await InService.GetInsCountAsync(search),
                        Sexes = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } },
                        HealthRegions = new List<HealthRegionOption>() { new HealthRegionOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } }
                    };

                    inPageIndexModel.Sexes.AddRange(await PatientService.GetSexOptionsAsync());
                    inPageIndexModel.HealthRegions.AddRange(await HealthRegionService.GetHealthRegionsAsync());

                    MedicCache.Set(key, inPageIndexModel);
                }

                return View(inPageIndexModel);
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

        public async Task<IActionResult> In(int id)
        {
            try
            {
                if (id > 0)
                {
                    string key = $"{nameof(InPageInModel)} - {id}";

                    if (!MedicCache.TryGetValue(key, out InPageInModel inPageInModel))
                    {
                        inPageInModel = new InPageInModel()
                        {
                            Title = MedicDataLocalization.Get("InView"),
                            Description = MedicDataLocalization.Get("InView"),
                            Keywords = MedicDataLocalization.Get("InSummary"),
                            InViewModel = await InService.GetInAsync(id)
                        };

                        MedicCache.Set(key, inPageInModel);
                    }

                    return View(inPageInModel);
                }

                return RedirectToAction(nameof(InController.Index), GetControllerName(nameof(InController)));
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