using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.Transfers;
using Medic.AppModels.Transfers;
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
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.App.Controllers
{
    public class TransferController : LookupsBaseController
    {
        private readonly ITransferService TransferService;
        private readonly IMedicLoggerService MedicLoggerService;
        private readonly IToEHRConverter ToEHRConverter;
        private readonly IFormattableFactory FormattableFactory;

        public TransferController(
            ITransferService transferService,
            IMedicLoggerService medicLoggerService,
            IToEHRConverter toEHRConverter,
            IFormattableFactory formattableFactory,
            IPatientService patientService, 
            IHealthRegionService healthRegionService, 
            ICacheable medicCache, 
            MedicDataLocalization medicDataLocalization) : 
            base(patientService, healthRegionService, medicCache, medicDataLocalization)
        {
            this.TransferService = transferService ?? throw new ArgumentNullException(nameof(transferService));
            this.MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
            this.ToEHRConverter = toEHRConverter ?? throw new ArgumentNullException(nameof(toEHRConverter));
            this.FormattableFactory = formattableFactory ?? throw new ArgumentNullException(nameof(formattableFactory));
        }

        public async Task<IActionResult> Index(TransferSearch search, int page = 1)
        {
            try
            {
                TransferWhereBuilder plannedWhereBuilder = new TransferWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;

                List<TransferPreviewViewModel> trasnfers = await GetPage(search, plannedWhereBuilder, searchParams, page);

                string trasnferCountKey = $"{MedicConstants.Transfers} - {searchParams}";

                if (!base.MedicCache.TryGetValue(trasnferCountKey, out int trasnfersCount))
                {
                    trasnfersCount = await TransferService
                        .GetTrasnfersCountAsync(plannedWhereBuilder);

                    base.MedicCache.Set(trasnferCountKey, trasnfersCount);
                }

                return View(new TransferPageIndexModel()
                {
                    Transfers = trasnfers,
                    Title = MedicDataLocalization.Get(MedicDataLocalization.Transfers),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.Transfers),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.TransfersSummary),
                    Search = search,
                    CurrentPage = page,
                    TotalPages = base.TotalPages((int)search.Length, trasnfersCount),
                    TotalResults = trasnfersCount
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

        public async Task<IActionResult> Transfer(int id)
        {
            try
            {
                TransferViewModel model;
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

                return View(new TransferPageTransferModel()
                {
                    Title = MedicDataLocalization.Get(MedicDataLocalization.Transfer),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.Transfer),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.TransferSummary),
                    Transfer = model,
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
                    TransferViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    EhrExtract ehrExtractModel = ToEHRConverter.Convert(model, nameof(TransferViewModel), MedicConstants.ItupMedic);

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
                    TransferViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    EhrExtract ehrExtractModel = ToEHRConverter.Convert(model, nameof(TransferViewModel), MedicConstants.ItupMedic);

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

        public async Task<IActionResult> Excel(TransferSearch search, int page = 1)
        {
            try
            {
                TransferWhereBuilder transferWhereBuilder = new TransferWhereBuilder(search);

                string searchParams = search != default ? search.ToString() : default;

                List<TransferPreviewViewModel> transfers = await GetPage(search, transferWhereBuilder, searchParams, page);

                if (transfers == default)
                {
                    return BadRequest();
                }

                return await base.FormatModel<TransferPreviewViewModel>(transfers, MedicDataLocalization.Plannings, FormattableFactory);
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

        private async Task<TransferViewModel> GetModelById(int id)
        {
            TransferViewModel model;

            string key = $"{nameof(TransferViewModel)} - {id}";

            if (!base.MedicCache.TryGetValue(key, out model))
            {
                model = await TransferService.GetTrasnferAsync(id);

                base.MedicCache.Set(key, model);
            }

            return model;
        }

        private async Task<List<TransferPreviewViewModel>> GetPage(TransferSearch search, TransferWhereBuilder plannedWhereBuilder, string searchParams, int page)
        {
            int pageLength = (int)search.Length;
            int startIndex = base.GetStartIndex(pageLength, page);

            string transferKey = $"{nameof(TransferPreviewViewModel)} - {startIndex} - {searchParams}";

            if (!base.MedicCache.TryGetValue(transferKey, out List<TransferPreviewViewModel> plannings))
            {
                TransferHelperBuilder helperBuilder = new TransferHelperBuilder(search);

                plannings = await TransferService.GetTrasnfersAsync(plannedWhereBuilder, helperBuilder, startIndex);

                base.MedicCache.Set(transferKey, plannings);
            }

            return plannings;
        }

    }
}
