using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models;
using Medic.App.Models.Home;
using Medic.Cache.Contacts;
using Medic.Logs.Contracts;
using Medic.Logs.Models;
using Medic.Resources;
using Medic.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            MedicDataLocalization = мedicDataLocalization ?? throw new ArgumentNullException(nameof(мedicDataLocalization));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                string key = nameof(HomePageModel);

                if (!MedicCache.TryGetValue(key, out HomePageModel homePageModel))
                {
                    homePageModel = new HomePageModel()
                    {
                        CPFileSummaryViewModels = await CPFileService.GetSummaryByMonthAsync(),
                        HospitalPracticeSummaryViewModels = await HospitalPracticeService.GetSummaryByMonthAsync(),
                        PatientCount = await PatientService.GetPatientsCountAsync(default),
                        Title = MedicDataLocalization.Get("SummaryInformation"),
                        Description = MedicDataLocalization.Get("SummaryInformation"),
                        Keywords = MedicDataLocalization.Get("SummaryInformationKeywords")
                    };

                    MedicCache.Set(key, homePageModel);
                }
                
                return View(homePageModel);
            }
            catch(Exception ex)
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

        public async Task<IActionResult> Diags()
        {
            try
            {
                string key = nameof(HomePageDiagModel);

                if (!MedicCache.TryGetValue(key, out HomePageDiagModel homePageDiagModel))
                {
                    homePageDiagModel = new HomePageDiagModel()
                    {
                        DiagMKBSummaryViewModels = await DiagService.GetMKBSummaryAsync(),
                        Title = MedicDataLocalization.Get("Diags"),
                        Description = MedicDataLocalization.Get("Diags"),
                        Keywords = MedicDataLocalization.Get("SummaryInformationKeywords")
                    };

                    MedicCache.Set(key, homePageDiagModel);
                }
                
                return View(homePageDiagModel);
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

        public async Task<IActionResult> Diagnoses()
        {
            try
            {
                string key = nameof(HomePageDiagnoseModel);

                if (!MedicCache.TryGetValue(key, out HomePageDiagnoseModel homePageDiagnoseModel))
                {
                    homePageDiagnoseModel = new HomePageDiagnoseModel()
                    {
                        DiagnosesMKBSummaryViewModels = await DiagnoseService.MKBSummaryAsync(),
                        Title = MedicDataLocalization.Get("Diagnoses"),
                        Description = MedicDataLocalization.Get("Diagnoses"),
                        Keywords = MedicDataLocalization.Get("SummaryInformationKeywords"),
                    };

                    MedicCache.Set(key, homePageDiagnoseModel);
                }

                return View(homePageDiagnoseModel);
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
                }).Wait();

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
