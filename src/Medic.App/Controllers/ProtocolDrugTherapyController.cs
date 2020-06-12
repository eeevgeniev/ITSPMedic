using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.ProtocolDrugTherapy;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.ProtocolDrugTherapies;
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
    public class ProtocolDrugTherapyController : LookupsBaseController
    {
        private readonly IProtocolDrugTherapyService ProtocolDrugTherapyService;
        private readonly IDrugProtocolService DrugProtocolService;
        private readonly IMedicLoggerService MedicLoggerService;

        public ProtocolDrugTherapyController(
            IProtocolDrugTherapyService protocolDrugTherapyService,
            IDrugProtocolService drugProtocolService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
            : base (patientService, healthRegionService, medicCache, medicDataLocalization)
        {
            ProtocolDrugTherapyService = protocolDrugTherapyService ?? throw new ArgumentNullException(nameof(protocolDrugTherapyService));
            DrugProtocolService = drugProtocolService ?? throw new ArgumentNullException(nameof(drugProtocolService));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> Index(ProtocolDrugTherapySearch search, int page = 1)
        {
            try
            {
                int pageLength = (int)search.Length;
                int startIndex = base.GetStartIndex(pageLength, page);
                ProtocolDrugTherapyWhereBuilder protocolDrugTherapyWhereBuilder = new ProtocolDrugTherapyWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                string protocolDrugTherapiesKey = $"{nameof(ProtocolDrugTherapyPreviewViewModel)} - {startIndex} - {searchParams}";
                string protocolDrugTherapiesCountKey = $"{MedicConstants.ProtocolDrugTherapies} - {searchParams}";

                if (!base.MedicCache.TryGetValue(protocolDrugTherapiesKey, out List<ProtocolDrugTherapyPreviewViewModel> protocolDrugTherapies))
                {
                    ProtocolDrugTherapyHelperBuilder helperBuilder = new ProtocolDrugTherapyHelperBuilder(search);

                    protocolDrugTherapies = await ProtocolDrugTherapyService
                        .GetProtocolDrugTherapiesAsync(protocolDrugTherapyWhereBuilder, helperBuilder, startIndex);

                    base.MedicCache.Set(protocolDrugTherapiesKey, protocolDrugTherapies);
                }

                if (!base.MedicCache.TryGetValue(protocolDrugTherapiesCountKey, out int protocolDrugTherapiesCount))
                {
                    protocolDrugTherapiesCount = await ProtocolDrugTherapyService
                        .GetProtocolDrugTherapiesCountAsync(protocolDrugTherapyWhereBuilder);

                    base.MedicCache.Set(protocolDrugTherapiesCountKey, protocolDrugTherapiesCount);
                }

                List<string> atcNames = new List<string>() { default };

                if (!base.MedicCache.TryGetValue(MedicConstants.AtcNames, out List<string> addedAtcNames))
                {
                    addedAtcNames = await DrugProtocolService.GetDrugProtocolATCNames();

                    addedAtcNames.Sort((x, y) => x.CompareTo(y));

                    base.MedicCache.Set(MedicConstants.AtcNames, addedAtcNames);
                }

                atcNames.AddRange(addedAtcNames);

                List<SexOption> sexOptions = base.GetDefaultSexes();
                sexOptions.AddRange(await base.GetSexesAsync());

                List<HealthRegionOption> healthRegions = base.GetDefaultHealthRegions();
                healthRegions.AddRange(await base.GetHealthRegionsAsync());

                return View(new ProtocolDrugTherapyPageIndexModel()
                {
                    ProtocolDrugTherapies = protocolDrugTherapies,
                    Title = MedicDataLocalization.Get("ProtocolDrugTherapies"),
                    Description = MedicDataLocalization.Get("ProtocolDrugTherapies"),
                    Keywords = MedicDataLocalization.Get("ProtocolDrugTherapiesSummary"),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages(pageLength, protocolDrugTherapiesCount),
                    TotalResults = protocolDrugTherapiesCount,
                    Sexes = sexOptions,
                    HealthRegions = healthRegions,
                    ATCNames = atcNames
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

        public async Task<IActionResult> ProtocolDrugTherapy(int id)
        {
            try
            {
                ProtocolDrugTherapyViewModel model;
                string error = default;

                if (id < 0)
                {
                    model = default;
                    error = MedicDataLocalization.Get("InvalidId");
                }
                else
                {
                    string key = $"{nameof(ProtocolDrugTherapyViewModel)} - {id}";

                    if (!base.MedicCache.TryGetValue(key, out model))
                    {
                        model = await ProtocolDrugTherapyService.GetProtocolDrugTherapyAsync(id);

                        base.MedicCache.Set(key, model);
                    }
                }

                return View(new ProtocolDrugTherapyPageProtocolDrugTherapyModel()
                {
                    Title = MedicDataLocalization.Get("ProtocolDrugTherapy"),
                    Description = MedicDataLocalization.Get("ProtocolDrugTherapy"),
                    Keywords = MedicDataLocalization.Get("ProtocolDrugTherapySummary"),
                    ProtocolDrugTherapy = model,
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