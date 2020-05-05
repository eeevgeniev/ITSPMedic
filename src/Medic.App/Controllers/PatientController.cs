using Medic.App.Controllers.Base;
using Medic.App.Models.Patients;
using Medic.AppModels.Patients;
using Medic.AppModels.Sexes;
using Medic.Entities;
using Medic.Resources;
using Medic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.App.Controllers
{
    public class PatientController : MedicBaseController
    {
        private readonly IPatientService PatientService;
        private readonly PatientLocalization PatientLocalization;
        private readonly MedicDataLocalization MedicDataLocalization;

        public PatientController(IPatientService patientService, 
            PatientLocalization patientLocalization, 
            MedicDataLocalization medicDataLocalization)
        {
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            PatientLocalization = patientLocalization ?? throw new ArgumentNullException(nameof(patientLocalization));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(medicDataLocalization));
        }
        
        public async Task<IActionResult> Index(PatientSearch search = default, int page = 1)
        {
            try
            {
                int startIndex = page > 0 ? (page - 1) * 10 : 0;
                
                List<PatientPreviewViewModel> patients = await PatientService.GetPatientsByQueryAsync(search, startIndex, 10);
                int count = await PatientService.GetPatientsCountAsync(search);
                List<SexOption> sexes = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };
                sexes.AddRange(await PatientService.GetSexOptionsAsync());

                return View(new PatientPageIndexModel()
                {
                    Patients = patients,
                    Count = count,
                    CurrentPage = page,
                    Title = PatientLocalization.Get("PatientSearch"),
                    Search = search,
                    Description = PatientLocalization.Get("PatientSearch"),
                    Keywords = PatientLocalization.Get("PatientSearchMetaData"),
                    Sexes = sexes
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> Patient(int id)
        {
            try
            {
                if (id > 0)
                {
                    PatientViewModel patient = await PatientService.GetPatientAsync(id);

                    return View(new PateintPagePatientModel()
                    {
                        Patient = patient,
                        Title = PatientLocalization.Get("PatientData"),
                        Description = PatientLocalization.Get("PatientData"),
                        Keywords = PatientLocalization.Get("PatientViewMetaData"),
                    });
                }

                return RedirectToAction(nameof(PatientController.Index), GetControllerName(nameof(PatientController)));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}