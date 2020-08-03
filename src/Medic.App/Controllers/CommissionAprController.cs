using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.CommissionAprs;
using Medic.AppModels.CommissionAprs;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Sexes;
using Medic.Cache.Contacts;
using Medic.EHR.RM;
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
    public class CommissionAprController : LookupsBaseController
    {
        private readonly ICommissionAprService CommissionAprService;
        private readonly IMedicLoggerService MedicLoggerService;
        private readonly IToEHRConverter ToEHRConverter;
        private readonly IFormattableFactory FormattableFactory;

        public CommissionAprController(ICommissionAprService commissionAprService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            ICacheable medicCache,
            MedicDataLocalization medicDataLocalization,
            IMedicLoggerService medicLoggerService,
            IToEHRConverter toEHRConverter,
            IFormattableFactory formattableFactory)
            : base (patientService, healthRegionService, medicCache, medicDataLocalization)
        {
            CommissionAprService = commissionAprService ?? throw new ArgumentNullException(nameof(commissionAprService));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
            ToEHRConverter = toEHRConverter ?? throw new ArgumentNullException(nameof(toEHRConverter));
            FormattableFactory = formattableFactory ?? throw new ArgumentNullException(nameof(formattableFactory));
        }

        public async Task<IActionResult> Index(CommissionAprSearch search, int page = 1)
        {
            try
            {
                CommissionAprWhereBuilder commissionAprWhereBuilder = new CommissionAprWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;

                List<CommissionAprPreviewViewModel> commissionAprs = await GetPage(search, commissionAprWhereBuilder, searchParams, page);

                string commissionAprsCountKey = $"{MedicConstants.CommissionAprs} - {searchParams}";

                if (!base.MedicCache.TryGetValue(commissionAprsCountKey, out int commissionAprsCount))
                {
                    commissionAprsCount = await CommissionAprService
                        .GetCommissionAprsCountAsync(commissionAprWhereBuilder);

                    base.MedicCache.Set(commissionAprsCountKey, commissionAprsCount);
                }

                List<SexOption> sexOptions = base.GetDefaultSexes();
                sexOptions.AddRange(await base.GetSexesAsync());

                List<HealthRegionOption> healthRegions = base.GetDefaultHealthRegions();
                healthRegions.AddRange(await base.GetHealthRegionsAsync());

                return View(new CommissionAprPageIndexModel()
                {
                    CommissionAprs = commissionAprs,
                    Title = MedicDataLocalization.Get(MedicDataLocalization.CommissionAprs),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.CommissionAprs),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.CommissionAprsSummary),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages((int)search.Length, commissionAprsCount),
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

                if (id < 1)
                {
                    model = default;
                    error = MedicDataLocalization.Get(MedicDataLocalization.InvalidId);
                }
                else
                {
                    model = await GetModelById(id);
                }

                return View(new CommissionAprPageCommissionAprModel()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.CommissionApr),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.CommissionApr),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.CommissionAprSummary),
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

        public async Task<IActionResult> Xml(int id)
        {
            try
            {
                if (id < 1)
                {
                    return BadRequest();
                }
                else
                {
                    CommissionAprViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    ReferenceModel referenceModel = ToEHRConverter.Convert(model, nameof(CommissionAprViewModel));

                    return await base.FormatModel(referenceModel, FormattableFactory.CreateFormatter(FormatterEnum.XML));
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
                    return BadRequest();
                }
                else
                {
                    CommissionAprViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    ReferenceModel referenceModel = ToEHRConverter.Convert(model, nameof(CommissionAprViewModel));

                    return await base.FormatModel(referenceModel, FormattableFactory.CreateFormatter(FormatterEnum.Json));
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

        public async Task<IActionResult> Excel(CommissionAprSearch search, int page = 1)
        {
            try
            {
                CommissionAprWhereBuilder commissionAprWhereBuilder = new CommissionAprWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;

                List<CommissionAprPreviewViewModel> commissionAprs = await GetPage(search, commissionAprWhereBuilder, searchParams, page);

                if (commissionAprs == default)
                {
                    return BadRequest();
                }

                return await base.FormatModel<CommissionAprPreviewViewModel>(commissionAprs, MedicDataLocalization.CommissionAprs, FormattableFactory);
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

        private async Task<CommissionAprViewModel> GetModelById(int id)
        {
            CommissionAprViewModel model;

            string key = $"{nameof(CommissionAprViewModel)} - {id}";

            if (!base.MedicCache.TryGetValue(key, out model))
            {
                model = await CommissionAprService.GetCommissionAprAsync(id);

                base.MedicCache.Set(key, model);
            }

            return model;
        }

        private async Task<List<CommissionAprPreviewViewModel>> GetPage(CommissionAprSearch search, CommissionAprWhereBuilder commissionAprWhereBuilder, string searchParams,  int page)
        {
            int pageLength = (int)search.Length;
            int startIndex = base.GetStartIndex(pageLength, page);

            string commissionAprsKey = $"{nameof(CommissionAprPreviewViewModel)} - {startIndex} - {searchParams}";

            if (!base.MedicCache.TryGetValue(commissionAprsKey, out List<CommissionAprPreviewViewModel> commissionAprs))
            {
                CommissionAprHelperBuilder helperBuilder = new CommissionAprHelperBuilder(search);

                commissionAprs = await CommissionAprService
                    .GetCommissionAprsAsync(commissionAprWhereBuilder, helperBuilder, startIndex);

                base.MedicCache.Set(commissionAprsKey, commissionAprs);
            }

            return commissionAprs;
        }
    }
}