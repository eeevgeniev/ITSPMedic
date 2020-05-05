using Medic.App.Controllers.Base;
using Medic.App.Models.Outs;
using Medic.AppModels.Outs;
using Medic.AppModels.Sexes;
using Medic.AppModels.UsedDrugs;
using Medic.Resources;
using Medic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Medic.App.Controllers
{
    public class OutController : MedicBaseController
    {
        private readonly IOutService OutService;
        private readonly IPatientService PatientService;
        private readonly IUsedDrugService UsedDrugService;
        private readonly MedicDataLocalization MedicDataLocalization;

        public OutController(IOutService outService, 
            IPatientService patientService, 
            IUsedDrugService usedDrugService,
            MedicDataLocalization medicDataLocalization)
        {
            OutService = outService ?? throw new ArgumentNullException(nameof(outService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            UsedDrugService = usedDrugService ?? throw new ArgumentNullException(nameof(usedDrugService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(medicDataLocalization));
        }

        public async Task<IActionResult> Index(OutSearch search, int page = 1)
        {
            try
            {
                int startIndex = page > 0 ? (page - 1) * 10 : 0;

                List<OutPreviewViewModel> outs = await OutService.GetOutsAsync(search, startIndex, 10);
                int count = await OutService.GetOutsCountAsync(search);

                List<SexOption> sexes = new List<SexOption>() { new SexOption() { Id = null, Name = MedicDataLocalization.Get("NoSelection") } };
                sexes.AddRange(await PatientService.GetSexOptionsAsync());

                List<UsedDrugCodeOption> usedDrugCodes = new List<UsedDrugCodeOption>() { new UsedDrugCodeOption() { Key = string.Empty, Code = MedicDataLocalization.Get("NoSelection") } };

                usedDrugCodes.AddRange(await UsedDrugService.UsedDrugsByCodeAsync());

                return View(new OutPageIndexModel()
                {
                    Outs = outs,
                    Title = MedicDataLocalization.Get("OutsView"),
                    Description = MedicDataLocalization.Get("OutsView"),
                    Keywords = MedicDataLocalization.Get("OutsSummary"),
                    Search = search,
                    CurrentPage = page,
                    TotalCount = count,
                    Sexes = sexes,
                    UsedDrugCodes = usedDrugCodes
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IActionResult> Out(int id)
        {
            try
            {
                OutViewModel outViewModel = await OutService.GetOutAsyns(id);

                return View(new OutPageOutModel()
                {
                    Title = MedicDataLocalization.Get("OutView"),
                    Description = MedicDataLocalization.Get("OutView"),
                    Keywords = MedicDataLocalization.Get("OutSummary"),
                    OutViewModel = outViewModel
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
