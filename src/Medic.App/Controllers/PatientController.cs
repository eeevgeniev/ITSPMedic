using Medic.App.Controllers.Base;
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
        
        public async Task<IActionResult> Index()
        {
            Task<List<Patient>> patientsTask = PatientService.GetPatientsAsync();
            Task<int> countTask = PatientService.GetPatientsCountAsync();

            await Task.WhenAll(patientsTask, countTask);

            List<Patient> patients = patientsTask.Result;
            int count = countTask.Result;

            return View(patients);
        }

        public async Task<IActionResult> Patient(int id)
        {
            Patient patient = await PatientService.GetPatientAsync(id);

            return View(patient);
        }
    }
}