using Medic.App.Controllers.Base;
using Medic.App.Models.Patients;
using Medic.AppModels.Patients;
using Medic.AppModels.Sexes;
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
        
        public async Task<IActionResult> Index(PatientSearch search = default, int page = 1)
        {
            try
            {
                int startIndex = page > 0 ? (page - 1) * 10 : 0;
                string key = $"{nameof(PatientPageIndexModel)} - {startIndex} - {search?.ToString() ?? string.Empty}";

                if (!MedicCache.TryGetValue(key, out PatientPageIndexModel patientPageIndexModel))
                {
                    patientPageIndexModel = new PatientPageIndexModel()
                    {
                        Patients = await PatientService.GetPatientsByQueryAsync(search, startIndex, 10),
                        Count = await PatientService.GetPatientsCountAsync(search),
                        CurrentPage = page,
                        Title = PatientLocalization.Get("PatientSearch"),
                        Search = search,
                        Description = PatientLocalization.Get("PatientSearch"),
                        Keywords = PatientLocalization.Get("PatientSearchMetaData"),
                        Sexes = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } }
                    };

                    patientPageIndexModel.Sexes.AddRange(await PatientService.GetSexOptionsAsync());

                    MedicCache.Set(key, patientPageIndexModel);
                }

                return View(patientPageIndexModel);
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

        public async Task<IActionResult> Patient(int id)
        {
            try
            {
                if (id > 0)
                {
                    string key = $"{nameof(PateintPagePatientModel)} - {id}";

                    if (!MedicCache.TryGetValue(key, out PateintPagePatientModel pateintPagePatientModel))
                    {
                        pateintPagePatientModel = new PateintPagePatientModel()
                        {
                            Patient = await PatientService.GetPatientAsync(id),
                            Title = PatientLocalization.Get("PatientData"),
                            Description = PatientLocalization.Get("PatientData"),
                            Keywords = PatientLocalization.Get("PatientViewMetaData"),
                        };

                        MedicCache.Set(key, pateintPagePatientModel);
                    }
                    
                    return View(pateintPagePatientModel);
                }

                return RedirectToAction(nameof(PatientController.Index), GetControllerName(nameof(PatientController)));
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