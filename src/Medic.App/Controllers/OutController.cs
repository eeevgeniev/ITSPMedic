using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.Outs;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Outs;
using Medic.AppModels.Sexes;
using Medic.AppModels.UsedDrugs;
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
    public class OutController : MedicBaseController
    {
        private readonly IOutService OutService;
        private readonly IPatientService PatientService;
        private readonly IUsedDrugService UsedDrugService;
        private readonly IHealthRegionService HealthRegionService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly ICacheable MedicCache;
        private readonly IMedicLoggerService MedicLoggerService;

        public OutController(IOutService outService, 
            IPatientService patientService, 
            IUsedDrugService usedDrugService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
        {
            OutService = outService ?? throw new ArgumentNullException(nameof(outService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            UsedDrugService = usedDrugService ?? throw new ArgumentNullException(nameof(usedDrugService));
            HealthRegionService = healthRegionService ?? throw new ArgumentNullException(nameof(healthRegionService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(medicDataLocalization));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> Index(OutSearch search, int page = 1)
        {
            try
            {
                int pageLength = (int)search.Length;
                int startIndex = page > 0 ? (page - 1) * pageLength : 0;
                OutWhereBuilder outWhereBuilder = new OutWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                string outsKey = $"{nameof(OutPreviewViewModel)} - {startIndex} - {searchParams}";
                string outsCountKey = $"{MedicConstants.OutsCount} - {searchParams}";
                
                List<SexOption> sexOptions = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };
                List<HealthRegionOption> healthRegions = new List<HealthRegionOption>() { new HealthRegionOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };
                List<UsedDrugCodeOption> usedDrugs = new List<UsedDrugCodeOption>() { new UsedDrugCodeOption() { Key = string.Empty, Code = MedicDataLocalization.Get("NoSelection") } };

                if (!MedicCache.TryGetValue(outsKey, out List<OutPreviewViewModel> outs))
                {
                    OutHelperBuilder outHelperBuilder = new OutHelperBuilder(search);

                    outs = await OutService.GetOutsAsync(outWhereBuilder, outHelperBuilder, startIndex);

                    MedicCache.Set(outsKey, outs);
                }

                if (!MedicCache.TryGetValue(outsCountKey, out int outsCount))
                {
                    outsCount = await OutService.GetOutsCountAsync(outWhereBuilder);

                    MedicCache.Set(outsCountKey, outsCount);
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

                if (!MedicCache.TryGetValue(MedicConstants.UsedDrugs, out List<UsedDrugCodeOption> drugs))
                {
                    drugs = await UsedDrugService.UsedDrugsByCodeAsync();

                    MedicCache.Set(MedicConstants.UsedDrugs, drugs);
                }

                usedDrugs.AddRange(drugs);

                return View(new OutPageIndexModel()
                {
                    Outs = outs,
                    Title = MedicDataLocalization.Get("OutsView"),
                    Description = MedicDataLocalization.Get("OutsView"),
                    Keywords = MedicDataLocalization.Get("OutsSummary"),
                    Search = search,
                    CurrentPage = page,
                    TotalCount = outsCount,
                    Sexes = sexOptions,
                    UsedDrugCodes = usedDrugs,
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

        public async Task<IActionResult> Out(int id)
        {
            try
            {
                OutViewModel model;
                string error = default;

                if (id < 1)
                {
                    error = MedicDataLocalization.Get("InvalidId"); ;
                    model = default;
                }
                else
                {
                    string key = $"{nameof(OutViewModel)} - {id}";

                    if (!MedicCache.TryGetValue(key, out model))
                    {
                        model = await OutService.GetOutAsyns(id);

                        MedicCache.Set(key, model);
                    }

                    return View(new OutPageOutModel()
                    {
                        Title = MedicDataLocalization.Get("OutView"),
                        Description = MedicDataLocalization.Get("OutView"),
                        Keywords = MedicDataLocalization.Get("OutSummary"),
                        OutViewModel = model
                    });
                }

                return RedirectToAction(nameof(OutController.Index), GetControllerName(nameof(OutController)));
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