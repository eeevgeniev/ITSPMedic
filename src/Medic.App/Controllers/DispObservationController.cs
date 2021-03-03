using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.DispObservations;
using Medic.AppModels.DispObservations;
using Medic.AppModels.HealthRegions;
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
    public class DispObservationController : LookupsBaseController
    {
        private readonly IDispObservationService DispObservationService;
        private readonly IMedicLoggerService MedicLoggerService;
        private readonly IToEHRConverter ToEHRConverter;
        private readonly IFormattableFactory FormattableFactory;

        public DispObservationController(IDispObservationService dispObservationService,
            IPatientService patientService,
            IHealthRegionService healthRegionService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService,
            IToEHRConverter toEHRConverter,
            IFormattableFactory formattableFactory)
            : base (patientService, healthRegionService, medicCache, medicDataLocalization)
        {
            DispObservationService = dispObservationService ?? throw new ArgumentNullException(nameof(dispObservationService));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
            ToEHRConverter = toEHRConverter ?? throw new ArgumentNullException(nameof(toEHRConverter));
            FormattableFactory = formattableFactory ?? throw new ArgumentNullException(nameof(formattableFactory));
        }

        public async Task<IActionResult> Index(DispObservationSearch search, int page = 1)
        {
            try
            {
                DispObservationWhereBuilder dispObservationWhereBuilder = new DispObservationWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;

                List<DispObservationPreviewViewModel> dispObservations = await GetPage(search, dispObservationWhereBuilder, searchParams, page);

                string dispObservationsCountKey = $"{MedicConstants.DispObservations} - {searchParams}";

                if (!base.MedicCache.TryGetValue(dispObservationsCountKey, out int dispObservationsCount))
                {
                    dispObservationsCount = await DispObservationService
                        .GetDispObservationsCountAsync(dispObservationWhereBuilder);

                    base.MedicCache.Set(dispObservationsCountKey, dispObservationsCount);
                }

                List<SexOption> sexOptions = base.GetDefaultSexes();
                sexOptions.AddRange(await base.GetSexesAsync());

                List<HealthRegionOption> healthRegions = base.GetDefaultHealthRegions();
                healthRegions.AddRange(await base.GetHealthRegionsAsync());

                return View(new DispObservationPageIndexModel()
                {
                    DispObservations = dispObservations,
                    Title = MedicDataLocalization.Get(MedicDataLocalization.DispObservations),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.DispObservations),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.DispObservationsSummary),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages((int)search.Length, dispObservationsCount),
                    TotalResults = dispObservationsCount,
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

        public async Task<IActionResult> DispObservation(int id)
        {
            try
            {
                DispObservationViewModel model;
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

                return View(new DispObservationPageDispObservationModel()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.DispObservation),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.DispObservation),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.DispObservationSummary),
                    DispObservation = model,
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
                    DispObservationViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    EhrExtract ehrExtractModel = ToEHRConverter.Convert(model, nameof(DispObservationViewModel), MedicConstants.ItupMedic);

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
                    DispObservationViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    EhrExtract ehrExtractModel = ToEHRConverter.Convert(model, nameof(DispObservationViewModel), MedicConstants.ItupMedic);

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

        public async Task<IActionResult> Excel(DispObservationSearch search)
        {
            try
            {
                DispObservationWhereBuilder dispObservationWhereBuilder = new DispObservationWhereBuilder(search);

                List<DispObservationPreviewViewModel> dispObservations = 
                    await DispObservationService.GetDispObservationsAsync(dispObservationWhereBuilder, new DispObservationHelperBuilder(default), 0);

                if (dispObservations == default)
                {
                    return BadRequest();
                }

                return await base.FormatModel<DispObservationPreviewViewModel>(dispObservations, MedicDataLocalization.DispObservations, FormattableFactory);
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

        private async Task<DispObservationViewModel> GetModelById(int id)
        {
            DispObservationViewModel model;

            string key = $"{nameof(DispObservationViewModel)} - {id}";

            if (!base.MedicCache.TryGetValue(key, out model))
            {
                model = await DispObservationService.GetDispObservationAsync(id);

                base.MedicCache.Set(key, model);
            }

            return model;
        }

        private async Task<List<DispObservationPreviewViewModel>> GetPage(DispObservationSearch search, DispObservationWhereBuilder dispObservationWhereBuilder, string searchParams, int page)
        {
            int pageLength = (int)search.Length;
            int startIndex = base.GetStartIndex(pageLength, page);

            string dispObservationsKey = $"{nameof(DispObservationPreviewViewModel)} - {startIndex} - {searchParams}";

            if (!base.MedicCache.TryGetValue(dispObservationsKey, out List<DispObservationPreviewViewModel> dispObservations))
            {
                DispObservationHelperBuilder helperBuilder = new DispObservationHelperBuilder(search);

                dispObservations = await DispObservationService
                    .GetDispObservationsAsync(dispObservationWhereBuilder, helperBuilder, startIndex);

                base.MedicCache.Set(dispObservationsKey, dispObservations);
            }

            return dispObservations;
        }
    }
}