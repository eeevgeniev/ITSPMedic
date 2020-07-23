using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.Patients;
using Medic.AppModels.Patients;
using Medic.AppModels.Sexes;
using Medic.Cache.Contacts;
using Medic.EHR.RM;
using Medic.Formatters.Contracts;
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
    public class PatientController : SexBaseController
    {
        private readonly PatientLocalization PatientLocalization;
        private readonly IMedicLoggerService MedicLoggerService;
        private readonly IToEHRConverter ToEHRConverter;
        private readonly IFormattableFactory FormattableFactory;

        public PatientController(IPatientService patientService, 
            PatientLocalization patientLocalization, 
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService,
            IToEHRConverter toEHRConverter,
            IFormattableFactory formattableFactory)
            : base (patientService, medicCache, medicDataLocalization)
        {
            PatientLocalization = patientLocalization ?? throw new ArgumentNullException(nameof(patientLocalization));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
            ToEHRConverter = toEHRConverter ?? throw new ArgumentNullException(nameof(toEHRConverter));
            FormattableFactory = formattableFactory ?? throw new ArgumentNullException(nameof(formattableFactory));
        }
        
        public async Task<IActionResult> Index(PatientSearch search, int page = 1)
        {
            try
            {
                int pageLength = (int)search.Length;
                int startIndex = base.GetStartIndex(pageLength, page);
                string searchParams = search != default ? search.ToString() : default;

                string patientsKey = $"{nameof(PatientPreviewViewModel)} - {startIndex} - {searchParams}";
                string patientsCountKey = $"{MedicConstants.PatientsCount} - {searchParams}";

                PatientWhereBuilder patientWhereBuilder = new PatientWhereBuilder(search);

                if (!base.MedicCache.TryGetValue(patientsKey, out List<PatientPreviewViewModel> patientsModel))
                {
                    PatientHelperBuilder helperBuilder = new PatientHelperBuilder(search);

                    patientsModel = await PatientService.GetPatientsByQueryAsync(patientWhereBuilder, helperBuilder, startIndex);

                    base.MedicCache.Set(patientsKey, patientsModel);
                }

                if (!base.MedicCache.TryGetValue(patientsCountKey, out int patientsCount))
                {
                    patientsCount = await PatientService.GetPatientsCountAsync(patientWhereBuilder);

                    base.MedicCache.Set(patientsCountKey, patientsCount);
                }

                List<SexOption> sexOptions = base.GetDefaultSexes();
                sexOptions.AddRange(await base.GetSexesAsync());

                return View(new PatientPageIndexModel()
                {
                    Patients = patientsModel,
                    TotalPages = base.TotalPages(pageLength, patientsCount),
                    TotalResults = patientsCount,
                    CurrentPage = page,
                    Title = MedicDataLocalization.Get(MedicDataLocalization.Patients),
                    Search = search,
                    Description = MedicDataLocalization.Get(MedicDataLocalization.Patients),
                    Keywords = MedicDataLocalization.Get(MedicDataLocalization.PatientsSummary),
                    Sexes = sexOptions
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

        public async Task<IActionResult> Patient(int id)
        {
            try
            {
                PatientViewModel model;
                string error;
                
                if (id < 1)
                {
                    model = default;
                    error = MedicDataLocalization.Get(MedicDataLocalization.InvalidId);
                }
                else
                {
                    model = await GetModelById(id);
                }

                return View(new PatientPagePatientModel()
                {
                    Patient = model,
                    Title = PatientLocalization.Get(PatientLocalization.PatientData),
                    Description = PatientLocalization.Get(PatientLocalization.PatientData),
                    Keywords = PatientLocalization.Get(PatientLocalization.PatientViewMetaData),
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
                    PatientViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    ReferenceModel referenceModel = ToEHRConverter.Convert(model, nameof(PatientViewModel));
                    IDataFormattable xmlFormater = FormattableFactory.CreateXMLFormatter();

                    return new ContentResult()
                    {
                        Content = await xmlFormater.FormatObject(referenceModel),
                        ContentType = xmlFormater.MimeType,
                        StatusCode = 200
                    };
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
                    PatientViewModel model = await GetModelById(id);

                    if (model == default)
                    {
                        return BadRequest();
                    }

                    ReferenceModel referenceModel = ToEHRConverter.Convert(model, nameof(PatientViewModel));
                    IDataFormattable jsonFormater = FormattableFactory.CreateJsonFormatter();

                    return new ContentResult()
                    {
                        Content = await jsonFormater.FormatObject(referenceModel),
                        ContentType = jsonFormater.MimeType,
                        StatusCode = 200
                    };
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

        private async Task<PatientViewModel> GetModelById(int id)
        {
            PatientViewModel model;

            string key = $"{nameof(PatientViewModel)} - {id}";

            if (!base.MedicCache.TryGetValue(key, out model))
            {
                model = await PatientService.GetPatientAsync(id);

                base.MedicCache.Set(key, model);
            }

            return model;
        }
    }
}