using Medic.App.Controllers.Base;
using Medic.App.Models.Ins;
using Medic.AppModels.Ins;
using Medic.AppModels.Sexes;
using Medic.Resources;
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
        private readonly MedicDataLocalization MedicDataLocalization;

        public InController(IInService inService, IPatientService patientService, MedicDataLocalization medicDataLocalization)
        {
            InService = inService ?? throw new ArgumentNullException(nameof(inService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(MedicBaseController));
        }

        [HttpGet]
        public async Task<IActionResult> Index(InsSerach search, int page = 1)
        {
            try
            {
                int startIndex = page > 0 ? (page - 1) * 10 : 0;

                List<InPreviewViewModel> ins = await InService.GetInsAsync(search, startIndex, 10);
                int count = await InService.GetInsCountAsync(search);
                List<SexOption> sexes = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };
                sexes.AddRange(await PatientService.GetSexOptionsAsync());

                return View(new InPageIndexModel()
                {
                    Ins = ins,
                    Title = MedicDataLocalization.Get("InsView"),
                    Description = MedicDataLocalization.Get("InsView"),
                    Keywords = MedicDataLocalization.Get("InsSummary"),
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

        public async Task<IActionResult> In(int id)
        {
            try
            {
                InViewModel inViewModel = await InService.GetInAsync(id);

                return View(new InPageInModel()
                {
                    Title = MedicDataLocalization.Get("InView"),
                    Description = MedicDataLocalization.Get("InView"),
                    Keywords = MedicDataLocalization.Get("InSummary"),
                    InViewModel = inViewModel
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}