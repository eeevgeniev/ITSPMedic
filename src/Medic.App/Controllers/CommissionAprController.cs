using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.CommissionAprs;
using Medic.AppModels.CommissionAprs;
using Medic.AppModels.HealthRegions;
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
    public class CommissionAprController : LookupsBaseController
    {
        private readonly ICommissionAprService CommissionAprService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly IMedicLoggerService MedicLoggerService;

        public CommissionAprController(ICommissionAprService commissionAprService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
            : base (patientService, healthRegionService, medicCache)
        {
            CommissionAprService = commissionAprService ?? throw new ArgumentNullException(nameof(commissionAprService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(MedicBaseController));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> Index(CommissionAprSearch search, int page = 1)
        {
            try
            {
                int pageLength = (int)search.Length;
                int startIndex = base.GetStartIndex(pageLength, page);
                CommissionAprWhereBuilder protocolDrugTherapyWhereBuilder = new CommissionAprWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;
                string commissionAprsKey = $"{nameof(CommissionAprPreviewViewModel)} - {startIndex} - {searchParams}";
                string commissionAprsCountKey = $"{MedicConstants.CommissionAprs} - {searchParams}";

                List<SexOption> sexOptions = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };
                List<HealthRegionOption> healthRegions = new List<HealthRegionOption>() { new HealthRegionOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };

                if (!base.MedicCache.TryGetValue(commissionAprsKey, out List<CommissionAprPreviewViewModel> commissionAprs))
                {
                    CommissionAprHelperBuilder helperBuilder = new CommissionAprHelperBuilder(search);

                    commissionAprs = await CommissionAprService
                        .GetCommissionAprsAsync(protocolDrugTherapyWhereBuilder, helperBuilder, startIndex);

                    base.MedicCache.Set(commissionAprsKey, commissionAprs);
                }

                if (!base.MedicCache.TryGetValue(commissionAprsCountKey, out int commissionAprsCount))
                {
                    commissionAprsCount = await CommissionAprService
                        .GetCommissionAprsCountAsync(protocolDrugTherapyWhereBuilder);

                    base.MedicCache.Set(commissionAprsCountKey, commissionAprsCount);
                }

                sexOptions.AddRange(await base.GetSexes());

                healthRegions.AddRange(await base.GetHelathRegions());

                return View(new CommissionAprPageIndexModel()
                {
                    CommissionAprs = commissionAprs,
                    Title = MedicDataLocalization.Get("CommissionAprs"),
                    Description = MedicDataLocalization.Get("CommissionAprs"),
                    Keywords = MedicDataLocalization.Get("CommissionAprsSummary"),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages(pageLength, commissionAprsCount),
                    TotalResults = commissionAprsCount,
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

        public async Task<IActionResult> CommissionApr(int id)
        {
            try
            {
                CommissionAprViewModel model;
                string error = default;

                if (id < 0)
                {
                    model = default;
                    error = MedicDataLocalization.Get("InvalidId");
                }
                else
                {
                    string key = $"{nameof(CommissionAprViewModel)} - {id}";

                    if (!base.MedicCache.TryGetValue(key, out model))
                    {
                        model = await CommissionAprService.GetCommissionAprAsync(id);

                        base.MedicCache.Set(key, model);
                    }
                }

                return View(new CommissionAprPageCommissionAprModel()
                {
                    Title = MedicDataLocalization.Get("CommissionApr"),
                    Description = MedicDataLocalization.Get("CommissionApr"),
                    Keywords = MedicDataLocalization.Get("CommissionAprSummary"),
                    CommissionApr = model,
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