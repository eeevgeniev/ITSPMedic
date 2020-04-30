using Medic.App.Controllers.Base;
using Medic.App.Models.Patients;
using Medic.AppModels.Patients;
using Medic.Entities;
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

        public PatientController(IPatientService patientService)
        {
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }
        
        public async Task<IActionResult> Index(PatientSearch search = default, int page = 1)
        {
            try
            {
                int startIndex = page > 0 ? (page - 1) * 10 : 0;
                
                List<PatientPreviewViewModel> patients = await PatientService.GetPatientsByQueryAsync(search, startIndex, 10);
                int count = await PatientService.GetPatientsCountAsync(search);

                return View(new PatientPageIndexModel()
                {
                    Patients = patients,
                    Count = count,
                    CurrentPage = page,
                    Title = nameof(PatientController.Index),
                    Search = search,
                    Description = "Patient search",
                    Keywords = "patient, search"
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
                        Title = nameof(PatientController.Patient),
                        Description = "Patient data",
                        Keywords = "patient, information"
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