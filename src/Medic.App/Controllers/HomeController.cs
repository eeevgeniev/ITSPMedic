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
using Medic.Formatters.Contracts;
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
    public class HomeController : FormatterBaseController
    {
        private readonly ICPFileService CPFileService;
        private readonly IDiagnoseService DiagnoseService;
        private readonly IDiagService DiagService;
        private readonly IHospitalPracticeService HospitalPracticeService;
        private readonly IPatientService PatientService;
        private readonly IUsedDrugService UsedDrugService;
        private readonly ILogger<HomeController> Logger;
        private readonly ICacheable MedicCache;
        private readonly IMedicLoggerService MedicLoggerService;
        private readonly IFormattableFactory FormattableFactory;

        public HomeController(
            ICPFileService cpFileService,
            IDiagnoseService diagnoseService,
            IDiagService diagService,
            IHospitalPracticeService hospitalPracticeService,
            IPatientService patientService,
            IUsedDrugService usedDrugService,
            ILogger<HomeController> logger,
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService,
            IFormattableFactory formattableFactory)
            : base (medicDataLocalization)
        {
            CPFileService = cpFileService ?? throw new ArgumentNullException(nameof(cpFileService));
            DiagnoseService = diagnoseService ?? throw new ArgumentNullException(nameof(diagnoseService));
            DiagService = diagService ?? throw new ArgumentNullException(nameof(diagService));
            HospitalPracticeService = hospitalPracticeService ?? throw new ArgumentNullException(nameof(hospitalPracticeService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            UsedDrugService = usedDrugService ?? throw new ArgumentNullException(nameof(usedDrugService));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
            FormattableFactory = formattableFactory ?? throw new ArgumentNullException(nameof(formattableFactory));
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

                string countKey = $"{nameof(DiagMKBSummaryViewModel)} - count";

                List<DiagMKBSummaryViewModel> model = await GetDiags(startIndex, MedicConstants.SummaryPageLength);

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

        public async Task<IActionResult> DiagsAsExcel()
        {
            try
            {
                string key = $"{nameof(DiagMKBSummaryViewModel)} - all";

                if (!MedicCache.TryGetValue(key, out List<DiagMKBSummaryViewModel> model))
                {
                    model = await DiagService.GetMKBSummaryAsync();

                    MedicCache.Set(key, model);
                }

                if (model == default)
                {
                    return BadRequest();
                }

                return await base.FormatModel<DiagMKBSummaryViewModel>(model, MedicDataLocalization.Diags, FormattableFactory);
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

                string countKey = $"{nameof(DiagnoseMKBSummaryViewModel)} - count";

                List<DiagnoseMKBSummaryViewModel> model = await GetDiagnoses(startIndex, MedicConstants.SummaryPageLength);

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

        public async Task<IActionResult> DiagnosesAsExcel()
        {
            try
            {
                string key = $"{nameof(DiagnoseMKBSummaryViewModel)} - all";

                if (!MedicCache.TryGetValue(key, out List<DiagnoseMKBSummaryViewModel> model))
                {
                    model = await DiagnoseService.MKBSummaryAsync();

                    MedicCache.Set(key, model);
                }

                if (model == default)
                {
                    return BadRequest();
                }

                return await base.FormatModel<DiagnoseMKBSummaryViewModel>(model, MedicDataLocalization.Diagnoses, FormattableFactory);
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

                string keyCount = $"{nameof(UsedDrugsSummaryStatistic)} - count";

                List<UsedDrugsSummaryStatistic> model = await GetUsedDrugs(startIndex, MedicConstants.SummaryPageLength);

                if (!MedicCache.TryGetValue(keyCount, out int usedDrugsCount))
                {
                    usedDrugsCount = await UsedDrugService.UsedDrugsSummaryCountAsync();

                    MedicCache.Set(keyCount, usedDrugsCount);
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

        public async Task<IActionResult> UsedDrugsAsExcel()
        {
            try
            {
                string key = $"{nameof(UsedDrugsSummaryStatistic)} - all";

                if (!MedicCache.TryGetValue(key, out List<UsedDrugsSummaryStatistic> model))
                {
                    model = await UsedDrugService.UsedDrugsSummaryAsync();

                    MedicCache.Set(key, model);
                }

                if (model == default)
                {
                    return BadRequest();
                }

                return await base.FormatModel<UsedDrugsSummaryStatistic>(model, MedicDataLocalization.Diagnoses, FormattableFactory);
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
                            HttpOnly = false
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

        private async Task<List<DiagMKBSummaryViewModel>> GetDiags(int startIndex, int count)
        {
            string key = $"{nameof(DiagMKBSummaryViewModel)} - {startIndex}";

            if (!MedicCache.TryGetValue(key, out List<DiagMKBSummaryViewModel> model))
            {
                model = await DiagService.GetMKBSummaryAsync(startIndex, count);

                MedicCache.Set(key, model);
            }

            return model;
        }

        private async Task<List<DiagnoseMKBSummaryViewModel>> GetDiagnoses(int startIndex, int count)
        {
            string key = $"{nameof(DiagnoseMKBSummaryViewModel)} - {startIndex}";

            if (!MedicCache.TryGetValue(key, out List<DiagnoseMKBSummaryViewModel> model))
            {
                model = await DiagnoseService.MKBSummaryAsync(startIndex, count);

                MedicCache.Set(key, model);
            }

            return model;
        }

        private async Task<List<UsedDrugsSummaryStatistic>> GetUsedDrugs(int startIndex, int count)
        {
            string key = $"{nameof(UsedDrugsSummaryStatistic)} - {startIndex}";

            if (!MedicCache.TryGetValue(key, out List<UsedDrugsSummaryStatistic> model))
            {
                model = await UsedDrugService.UsedDrugsSummaryAsync(startIndex, count);

                MedicCache.Set(key, model);
            }

            return model;
        }
    }
}
