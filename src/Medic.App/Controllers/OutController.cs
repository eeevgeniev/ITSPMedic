using Medic.App.Controllers.Base;
using Medic.App.Models.Outs;
using Medic.AppModels.Outs;
using Medic.AppModels.Sexes;
using Medic.AppModels.UsedDrugs;
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
    public class OutController : MedicBaseController
    {
        private readonly IOutService OutService;
        private readonly IPatientService PatientService;
        private readonly IUsedDrugService UsedDrugService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly ICacheable MedicCache;
        private readonly IMedicLoggerService MedicLoggerService;

        public OutController(IOutService outService, 
            IPatientService patientService, 
            IUsedDrugService usedDrugService,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
        {
            OutService = outService ?? throw new ArgumentNullException(nameof(outService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            UsedDrugService = usedDrugService ?? throw new ArgumentNullException(nameof(usedDrugService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(medicDataLocalization));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> Index(OutSearch search, int page = 1)
        {
            try
            {
                int startIndex = page > 0 ? (page - 1) * 10 : 0;
                string key = $"{nameof(OutPageIndexModel)} - {startIndex} - {search?.ToString() ?? string.Empty}";

                if (!MedicCache.TryGetValue(key, out OutPageIndexModel outPageIndexModel))
                {
                    outPageIndexModel = new OutPageIndexModel()
                    {
                        Outs = await OutService.GetOutsAsync(search, startIndex, 10),
                        Title = MedicDataLocalization.Get("OutsView"),
                        Description = MedicDataLocalization.Get("OutsView"),
                        Keywords = MedicDataLocalization.Get("OutsSummary"),
                        Search = search,
                        CurrentPage = page,
                        TotalCount = await OutService.GetOutsCountAsync(search),
                        Sexes = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } },
                        UsedDrugCodes = new List<UsedDrugCodeOption>() { new UsedDrugCodeOption() { Key = string.Empty, Code = MedicDataLocalization.Get("NoSelection") } }
                    };

                    outPageIndexModel.Sexes.AddRange(await PatientService.GetSexOptionsAsync());
                    outPageIndexModel.UsedDrugCodes.AddRange(await UsedDrugService.UsedDrugsByCodeAsync());

                    MedicCache.Set(key, outPageIndexModel);
                }

                return View(outPageIndexModel);
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

        public async Task<IActionResult> Out(int id)
        {
            try
            {
                if (id > 0)
                {
                    string key = $"{nameof(OutPageOutModel)} - {id}";

                    if (!MedicCache.TryGetValue(key, out OutPageOutModel outPageOutModel))
                    {
                        outPageOutModel = new OutPageOutModel()
                        {
                            Title = MedicDataLocalization.Get("OutView"),
                            Description = MedicDataLocalization.Get("OutView"),
                            Keywords = MedicDataLocalization.Get("OutSummary"),
                            OutViewModel = await OutService.GetOutAsyns(id)
                        };

                        MedicCache.Set(key, outPageOutModel);
                    }

                    return View(outPageOutModel);
                }

                return RedirectToAction(nameof(OutController.Index), GetControllerName(nameof(OutController)));
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
