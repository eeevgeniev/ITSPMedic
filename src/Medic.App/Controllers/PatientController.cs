using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.Patients;
using Medic.AppModels.Patients;
using Medic.AppModels.Sexes;
using Medic.Cache.Contacts;
using Medic.Logs.Contracts;
using Medic.Logs.Models;
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
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly IMedicLoggerService MedicLoggerService;

        public PatientController(IPatientService patientService, 
            PatientLocalization patientLocalization, 
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
            : base (patientService, medicCache)
        {
            PatientLocalization = patientLocalization ?? throw new ArgumentNullException(nameof(patientLocalization));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(medicDataLocalization));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
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

                List<PatientPreviewViewModel> patientsModel;
                List<SexOption> sexOptions = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };

                PatientWhereBuilder patientWhereBuilder = new PatientWhereBuilder(search);

                if (!base.MedicCache.TryGetValue(patientsKey, out patientsModel))
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

                sexOptions.AddRange(await base.GetSexes());

                return View(new PatientPageIndexModel()
                {
                    Patients = patientsModel,
                    TotalPages = base.TotalPages(pageLength, patientsCount),
                    TotalResults = patientsCount,
                    CurrentPage = page,
                    Title = PatientLocalization.Get("Patients"),
                    Search = search,
                    Description = PatientLocalization.Get("Patients"),
                    Keywords = PatientLocalization.Get("PatientsSummary"),
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
                    error = MedicDataLocalization.Get("InvalidId");
                }
                else
                {
                    string key = $"{nameof(PatientViewModel)} - {id}";

                    if (!base.MedicCache.TryGetValue(key, out model))
                    {
                        model = await PatientService.GetPatientAsync(id);

                        base.MedicCache.Set(key, model);
                    }
                }

                return View(new PateintPagePatientModel()
                {
                    Patient = model,
                    Title = PatientLocalization.Get("PatientData"),
                    Description = PatientLocalization.Get("PatientData"),
                    Keywords = PatientLocalization.Get("PatientViewMetaData"),
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
    }
}