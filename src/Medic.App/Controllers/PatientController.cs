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
    public class PatientController : MedicBaseController
    {
        private readonly IPatientService PatientService;
        private readonly PatientLocalization PatientLocalization;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly ICacheable MedicCache;
        private readonly IMedicLoggerService MedicLoggerService;

        public PatientController(IPatientService patientService, 
            PatientLocalization patientLocalization, 
            MedicDataLocalization medicDataLocalization,
            ICacheable medicCache,
            IMedicLoggerService medicLoggerService)
        {
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            PatientLocalization = patientLocalization ?? throw new ArgumentNullException(nameof(patientLocalization));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(medicDataLocalization));
            MedicCache = medicCache ?? throw new ArgumentNullException(nameof(medicCache));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }
        
        public async Task<IActionResult> Index(PatientSearch search, int page = 1)
        {
            try
            {
                int patientsToTake = (int)search.Length;
                
                int startIndex = page > 0 ? (page - 1) * patientsToTake : 0;

                string patientsKey = $"{nameof(PatientPreviewViewModel)} - {startIndex} - {search?.ToString() ?? string.Empty}";
                string patientsCountKey = $"{MedicConstants.PatientsCount} - {(search != default ? search.ToString() : default)}";

                List<PatientPreviewViewModel> patientsModel;
                List<SexOption> sexOptions = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };

                PatientWhereBuilder patientWhereBuilder = new PatientWhereBuilder(search);

                if (!MedicCache.TryGetValue(patientsKey, out patientsModel))
                {
                    PatientHelperBuilder helperBuilder = new PatientHelperBuilder(search);

                    patientsModel = await PatientService.GetPatientsByQueryAsync(patientWhereBuilder, helperBuilder, startIndex);

                    MedicCache.Set(patientsKey, patientsModel);
                }

                if (!MedicCache.TryGetValue(patientsCountKey, out int patientsCount))
                {
                    patientsCount = await PatientService.GetPatientsCountAsync(patientWhereBuilder);

                    MedicCache.Set(patientsCountKey, patientsCount);
                }

                if (!MedicCache.TryGetValue(MedicConstants.SexKeyName, out List<SexOption> options))
                {
                    options = await PatientService.GetSexOptionsAsync();

                    MedicCache.Set(MedicConstants.SexKeyName, options);
                }

                sexOptions.AddRange(options);

                return View(new PatientPageIndexModel()
                {
                    Patients = patientsModel,
                    Count = patientsCount,
                    CurrentPage = page,
                    Title = PatientLocalization.Get("PatientSearch"),
                    Search = search,
                    Description = PatientLocalization.Get("PatientSearch"),
                    Keywords = PatientLocalization.Get("PatientSearchMetaData"),
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

                    if (!MedicCache.TryGetValue(key, out model))
                    {
                        model = await PatientService.GetPatientAsync(id);

                        MedicCache.Set(key, model);
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