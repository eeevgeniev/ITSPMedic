using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Medic.App.Models;
using Medic.Services.Contracts;
using Medic.AppModels.CPFiles;
using Medic.AppModels.HospitalPractices;
using Medic.AppModels.Diagnoses;
using Medic.AppModels.Diags;
using Medic.App.Models.Home;

namespace Medic.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICPFileService CPFileService;
        private readonly IDiagnoseService DiagnoseService;
        private readonly IDiagService DiagService;
        private readonly IHospitalPracticeService HospitalPracticeService;
        private readonly IPatientService PatientService;

        private readonly ILogger<HomeController> Logger;


        public HomeController(
            ICPFileService cpFileService,
            IDiagnoseService diagnoseService,
            IDiagService diagService,
            IHospitalPracticeService hospitalPracticeService,
            IPatientService patientService,
            ILogger<HomeController> logger)
        {
            CPFileService = cpFileService ?? throw new ArgumentNullException(nameof(cpFileService));
            DiagnoseService = diagnoseService ?? throw new ArgumentNullException(nameof(diagnoseService));
            DiagService = diagService ?? throw new ArgumentNullException(nameof(diagService));
            HospitalPracticeService = hospitalPracticeService ?? throw new ArgumentNullException(nameof(hospitalPracticeService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));

            Logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<CPFileSummaryViewModel> cpFileSummaryViewModels = await CPFileService.GetSummary();
            List<HospitalPracticeSummaryViewModel> hospitalPracticeSummaryViewModels = await HospitalPracticeService.GetSummary();
            int patientCount = await PatientService.GetPatientsCountAsync(default);

            return View(new HomePageModel()
            {
                CPFileSummaryViewModels = cpFileSummaryViewModels,
                HospitalPracticeSummaryViewModels = hospitalPracticeSummaryViewModels,
                PatientCount = patientCount,
                Title = nameof(HomeController.Index),
                Description = "Summary information",
                Keywords = "Statistic information, summary"
            });
        }

        public async Task<IActionResult> Diags()
        {
            List<DiagMKBSummaryViewModel> diagMKBSummaryViewModels = await DiagService.GetMKBSummary();

            return View(new HomePageDiagModel()
            {
                DiagMKBSummaryViewModels = diagMKBSummaryViewModels,
                Title = nameof(HomeController.Diags),
                Description = "Diag information",
                Keywords = "Statistic information, diag, mkb"
            });
        }

        public async Task<IActionResult> Diagnoses()
        {
            List<DiagnosesMKBSummaryViewModel> diagnosesMKBSummaryViewModels = await DiagnoseService.MKBSummary();

            return View(new HomePageDiagnoseModel()
            {
                DiagnosesMKBSummaryViewModels = diagnosesMKBSummaryViewModels,
                Title = nameof(HomeController.Diagnoses),
                Description = "Diagnoses information",
                Keywords = "Statistic information, diagnoses, mkb"
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
