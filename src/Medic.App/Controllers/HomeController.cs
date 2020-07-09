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
    public class HomeController : PageBasedController
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
                    Title = MedicDataLocalization.Get(MedicDataLocalization.SummaryInformation),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.SummaryInformation),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.SummaryInformationKeywords)
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

        public async Task<IActionResult> Diags(int page = 1)
        {
            try
            {
                int startIndex = base.GetStartIndex(MedicConstants.SummaryPageLength, page);

                string key = $"{nameof(DiagMKBSummaryViewModel)} - {startIndex}";
                string countKey = $"{nameof(DiagMKBSummaryViewModel)} - count";

                if (!MedicCache.TryGetValue(key, out List<DiagMKBSummaryViewModel> model))
                {
                    model = await DiagService.GetMKBSummaryAsync(startIndex, MedicConstants.SummaryPageLength);

                    MedicCache.Set(key, model);
                }

                if (!MedicCache.TryGetValue(countKey, out int diagsCount))
                {
                    diagsCount = await DiagService.GetMKBSummaryCountAsync();

                    MedicCache.Set(countKey, diagsCount);
                }

                return View(new HomePageDiagModel()
                {
                    DiagMKBSummaryViewModels = model,
                    Title = MedicDataLocalization.Get(MedicDataLocalization.Diags),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.Diags),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.SummaryInformationKeywords),
                    CurrentPage = page,
                    TotalPages = base.TotalPages(MedicConstants.SummaryPageLength, diagsCount),
                    TotalResults = diagsCount
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

        public async Task<IActionResult> Diagnoses(int page = 1)
        {
            try
            {
                int startIndex = base.GetStartIndex(MedicConstants.SummaryPageLength, page);

                string key = $"{nameof(DiagnoseMKBSummaryViewModel)} - {startIndex}";
                string countKey = $"{nameof(DiagnoseMKBSummaryViewModel)} - count";

                if (!MedicCache.TryGetValue(key, out List<DiagnoseMKBSummaryViewModel> model))
                {
                    model = await DiagnoseService.MKBSummaryAsync(startIndex, MedicConstants.SummaryPageLength);

                    MedicCache.Set(key, model);
                }

                if (!MedicCache.TryGetValue(countKey, out int diagnosesCount))
                {
                    diagnosesCount = await DiagnoseService.GetMKBSummaryCountAsync();

                    MedicCache.Set(countKey, diagnosesCount);
                }

                return View(new HomePageDiagnoseModel()
                {
                    DiagnosesMKBSummaryViewModels = model,
                    Title = MedicDataLocalization.Get(MedicDataLocalization.Diagnoses),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.Diagnoses),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.SummaryInformationKeywords),
                    CurrentPage = page,
                    TotalPages = base.TotalPages(MedicConstants.SummaryPageLength, diagnosesCount),
                    TotalResults = diagnosesCount
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

        public async Task<IActionResult> UsedDrugs(int page = 1)
        {
            try
            {
                int startIndex = base.GetStartIndex(MedicConstants.SummaryPageLength, page);

                string key = $"{nameof(UsedDrugsSummaryStatistic)} - {startIndex}";
                string keyCount = $"{nameof(UsedDrugsSummaryStatistic)} - count";

                if (!MedicCache.TryGetValue(key, out List<UsedDrugsSummaryStatistic> model))
                {
                    model = await UsedDrugService.UsedDrugsSummaryAsync(startIndex, MedicConstants.SummaryPageLength);

                    MedicCache.Set(key, model);
                }

                if (!MedicCache.TryGetValue(keyCount, out int usedDrugsCount))
                {
                    usedDrugsCount = await UsedDrugService.UsedDrugsSummaryCountAsync();

                    MedicCache.Set(key, usedDrugsCount);
                }

                return View(new HomePageUsedDrugsModel()
                {
                    UsedDrugsSummary = model,
                    Title = MedicDataLocalization.Get(MedicDataLocalization.UsedDrug),
                    Description = MedicDataLocalization.Get(MedicDataLocalization.UsedDrugs),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.UsedDrugsInformationKeywords),
                    CurrentPage = page,
                    TotalPages = base.TotalPages(MedicConstants.SummaryPageLength, usedDrugsCount),
                    TotalResults = usedDrugsCount
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
