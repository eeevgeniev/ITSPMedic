using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models;
using Medic.App.Models.Home;
using Medic.AppModels.CPFiles;
using Medic.AppModels.Diagnoses;
using Medic.AppModels.Diags;
using Medic.AppModels.HospitalPractices;
using Medic.Resources;
using Medic.Services.Contracts;
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
    public class HomeController : MedicBaseController
    {
        private readonly ICPFileService CPFileService;
        private readonly IDiagnoseService DiagnoseService;
        private readonly IDiagService DiagService;
        private readonly IHospitalPracticeService HospitalPracticeService;
        private readonly IPatientService PatientService;
        private readonly ILogger<HomeController> Logger;
        private readonly MedicDataLocalization MedicDataLocalization;

        public HomeController(
            ICPFileService cpFileService,
            IDiagnoseService diagnoseService,
            IDiagService diagService,
            IHospitalPracticeService hospitalPracticeService,
            IPatientService patientService,
            ILogger<HomeController> logger,
            MedicDataLocalization мedicDataLocalization)
        {
            CPFileService = cpFileService ?? throw new ArgumentNullException(nameof(cpFileService));
            DiagnoseService = diagnoseService ?? throw new ArgumentNullException(nameof(diagnoseService));
            DiagService = diagService ?? throw new ArgumentNullException(nameof(diagService));
            HospitalPracticeService = hospitalPracticeService ?? throw new ArgumentNullException(nameof(hospitalPracticeService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            MedicDataLocalization = мedicDataLocalization ?? throw new ArgumentNullException(nameof(мedicDataLocalization));
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<CPFileSummaryViewModel> cpFileSummaryViewModels = await CPFileService.GetSummaryByMonthAsync();
                List<HospitalPracticeSummaryViewModel> hospitalPracticeSummaryViewModels = await HospitalPracticeService.GetSummaryByMonthAsync();
                int patientCount = await PatientService.GetPatientsCountAsync(default);

                return View(new HomePageModel()
                {
                    CPFileSummaryViewModels = cpFileSummaryViewModels,
                    HospitalPracticeSummaryViewModels = hospitalPracticeSummaryViewModels,
                    PatientCount = patientCount,
                    Title = MedicDataLocalization.Get("SummaryInformation"),
                    Description = MedicDataLocalization.Get("SummaryInformation"),
                    Keywords = MedicDataLocalization.Get("SummaryInformationKeywords")
                });
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> Diags()
        {
            try
            {
                List<DiagMKBSummaryViewModel> diagMKBSummaryViewModels = await DiagService.GetMKBSummaryAsync();

                return View(new HomePageDiagModel()
                {
                    DiagMKBSummaryViewModels = diagMKBSummaryViewModels,
                    Title = MedicDataLocalization.Get("Diags"),
                    Description = MedicDataLocalization.Get("Diags"),
                    Keywords = MedicDataLocalization.Get("SummaryInformationKeywords")
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> Diagnoses()
        {
            try
            {
                List<DiagnoseMKBSummaryViewModel> diagnosesMKBSummaryViewModels = await DiagnoseService.MKBSummaryAsync();

                return View(new HomePageDiagnoseModel()
                {
                    DiagnosesMKBSummaryViewModels = diagnosesMKBSummaryViewModels,
                    Title = MedicDataLocalization.Get("Diagnoses"),
                    Description = MedicDataLocalization.Get("Diagnoses"),
                    Keywords = MedicDataLocalization.Get("SummaryInformationKeywords"),
                });
            }
            catch (Exception ex)
            {
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
                throw;
            }
        }

        public IActionResult Privacy(string lang)
        {
            return RedirectToAction(nameof(HomeController.Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
