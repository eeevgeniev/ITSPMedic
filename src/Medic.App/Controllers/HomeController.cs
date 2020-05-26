using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models;
using Medic.App.Models.Home;
using Medic.AppModels.CPFiles;
using Medic.AppModels.Diagnoses;
using Medic.AppModels.Diags;
using Medic.AppModels.HospitalPractices;
using Medic.AppModels.UsedDrugs;
using Medic.Cache.Contacts;
using Medic.Logs.Contracts;
using Medic.Logs.Models;
using Medic.Resources;
using Medic.Services.Contracts;
using Medic.Services.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.App.Controllers
{
    [Authorize]
    public class HomeController : MedicBaseController
    {
        private readonly ICPFileService CPFileService;
        private readonly IDiagnoseService DiagnoseService;
        private readonly IDiagService DiagService;
        private readonly IHospitalPracticeService HospitalPracticeService;
        private readonly IPatientService PatientService;
        private readonly IUsedDrugService UsedDrugService;
        private readonly ILogger<HomeController> Logger;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly ICacheable MedicCache;
        private readonly IMedicLoggerService MedicLoggerService;

        public HomeController(
            ICPFileService cpFileService,
            IDiagnoseService diagnoseService,
            IDiagService diagService,
            IHospitalPracticeService hospitalPracticeService,
            IPatientService patientService,
            IUsedDrugService usedDrugService,
            ILogger<HomeController> logger,
            MedicDataLocalization мedicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
        {
            CPFileService = cpFileService ?? throw new ArgumentNullException(nameof(cpFileService));
            DiagnoseService = diagnoseService ?? throw new ArgumentNullException(nameof(diagnoseService));
            DiagService = diagService ?? throw new ArgumentNullException(nameof(diagService));
            HospitalPracticeService = hospitalPracticeService ?? throw new ArgumentNullException(nameof(hospitalPracticeService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            UsedDrugService = usedDrugService ?? throw new ArgumentNullException(nameof(usedDrugService));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            MedicDataLocalization = мedicDataLocalization ?? throw new ArgumentNullException(nameof(мedicDataLocalization));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                string cpFileKey = nameof(CPFileSummaryViewModel);
                string hospitalPracticeKey = nameof(HospitalPracticeSummaryViewModel);

                if (!MedicCache.TryGetValue(cpFileKey, out List<CPFileSummaryViewModel> cpFiles))
                {
                    cpFiles = await CPFileService.GetSummaryByMonthAsync();

                    MedicCache.Set(cpFileKey, cpFiles);
                }

                if (!MedicCache.TryGetValue(hospitalPracticeKey, out List<HospitalPracticeSummaryViewModel> hospitalPractices))
                {
                    hospitalPractices = await HospitalPracticeService.GetSummaryByMonthAsync();

                    MedicCache.Set(hospitalPracticeKey, hospitalPractices);
                }

                if (!MedicCache.TryGetValue(MedicConstants.PatientsCount, out int patientsCount))
                {
                    patientsCount = await PatientService.GetPatientsCountAsync(new PatientWhereBuilder(default));

                    MedicCache.Set(MedicConstants.PatientsCount, patientsCount);
                }

                return View(new HomePageModel()
                {
                    CPFileSummaryViewModels = cpFiles,
                    HospitalPracticeSummaryViewModels = hospitalPractices,
                    PatientCount = patientsCount,
                    Title = MedicDataLocalization.Get("SummaryInformation"),
                    Description = MedicDataLocalization.Get("SummaryInformation"),
                    Keywords = MedicDataLocalization.Get("SummaryInformationKeywords")
                });
            }
            catch(Exception ex)
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

        public async Task<IActionResult> Diags()
        {
            try
            {
                string key = nameof(DiagMKBSummaryViewModel);

                if (!MedicCache.TryGetValue(key, out List<DiagMKBSummaryViewModel> model))
                {
                    model = await DiagService.GetMKBSummaryAsync();

                    MedicCache.Set(key, model);
                }
                
                return View(new HomePageDiagModel()
                {
                    DiagMKBSummaryViewModels = model,
                    Title = MedicDataLocalization.Get("Diags"),
                    Description = MedicDataLocalization.Get("Diags"),
                    Keywords = MedicDataLocalization.Get("SummaryInformationKeywords")
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

        public async Task<IActionResult> Diagnoses()
        {
            try
            {
                string key = nameof(DiagnoseMKBSummaryViewModel);

                if (!MedicCache.TryGetValue(key, out List<DiagnoseMKBSummaryViewModel> model))
                {
                    model = await DiagnoseService.MKBSummaryAsync();

                    MedicCache.Set(key, model);
                }

                return View(new HomePageDiagnoseModel()
                {
                    DiagnosesMKBSummaryViewModels = model,
                    Title = MedicDataLocalization.Get("Diagnoses"),
                    Description = MedicDataLocalization.Get("Diagnoses"),
                    Keywords = MedicDataLocalization.Get("SummaryInformationKeywords"),
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

        public async Task<IActionResult> UsedDrugs()
        {
            try
            {
                string key = nameof(UsedDrugsSummaryStatistic);

                if (!MedicCache.TryGetValue(key, out List<UsedDrugsSummaryStatistic> model))
                {
                    model = await UsedDrugService.UsedDrugsSummaryAsync();

                    MedicCache.Set(key, model);
                }

                return View(new HomePageUsedDrugsModel()
                {
                    UsedDrugsSummary = model,
                    Title = MedicDataLocalization.Get("UsedDrug"),
                    Description = MedicDataLocalization.Get("UsedDrugs"),
                    Keywords = MedicDataLocalization.Get("UsedDrugsInformationKeywords"),
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

        public IActionResult Language(string lang)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(lang))
                {
                    string language = lang.ToLower();

                    if (MedicConstants.AllowedLanguages.Contains(language))
                    {
                        CookieOptions options = new CookieOptions()
                        {
                            MaxAge = TimeSpan.FromDays(MedicConstants.LanguageCookieSpanInDays),
                            SameSite = SameSiteMode.Strict,
                            HttpOnly = true
                        };

                        HttpContext.Response.Cookies.Append(MedicConstants.LanguageCookieName, language, options);
                    }
                }

                return RedirectToAction(nameof(HomeController.Index), GetControllerName(nameof(HomeController)));
            }
            catch (Exception ex)
            {
                MedicLoggerService.SaveAsync(new Log()
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

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PageNotFound()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
