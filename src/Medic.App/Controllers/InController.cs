using Medic.App.Controllers.Base;
using Medic.App.Models.Ins;
using Medic.AppModels.Ins;
using Medic.AppModels.Sexes;
using Medic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.App.Controllers
{
    public class InController : MedicBaseController
    {
        private readonly IInService InService;
        private readonly IPatientService PatientService;

        public InController(IInService inService, IPatientService patientService)
        {
            InService = inService ?? throw new ArgumentNullException(nameof(inService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }

        [HttpGet]
        public async Task<IActionResult> Index(InsSerach search, int page = 1)
        {
            try
            {
                int startIndex = page > 0 ? (page - 1) * 10 : 0;

                List<InPreviewViewModel> ins = await InService.GetInsAsync(search, startIndex, 10);
                int count = await InService.GetInsCountAsync(search);
                List<SexOption> sexes = await PatientService.GetSexOptionsAsync();

                sexes.Add(new SexOption() { Id = null, Name = "No selection" });

                return View(new InPageIndexModel()
                {
                    Ins = ins,
                    Title = "Ins view",
                    Description = "Ins",
                    Keywords = "Ins, patients, mkb",
                    Search = search,
                    CurrentPage = page,
                    TotalCount = count,
                    Sexes = sexes
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}