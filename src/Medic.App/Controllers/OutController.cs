using Medic.App.Controllers.Base;
using Medic.App.Models.Outs;
using Medic.AppModels.Outs;
using Medic.AppModels.Sexes;
using Medic.AppModels.UsedDrugs;
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

        public OutController(IOutService outService, IPatientService patientService, IUsedDrugService usedDrugService)
        {
            OutService = outService ?? throw new ArgumentNullException(nameof(outService));
            PatientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
            UsedDrugService = usedDrugService ?? throw new ArgumentNullException(nameof(usedDrugService));
        }

        public async Task<IActionResult> Index(OutSearch search, int page = 1)
        {
            try
            {
                int startIndex = page > 0 ? (page - 1) * 10 : 0;

                List<OutPreviewViewModel> outs = await OutService.GetOutsAsync(search, startIndex, 10);
                int count = await OutService.GetOutsCountAsync(search);

                List<SexOption> sexes = new List<SexOption>() { new SexOption() { Id = null, Name = "No selection" } };
                sexes.AddRange(await PatientService.GetSexOptionsAsync());

                List<UsedDrugCodeOption> usedDrugCodes = new List<UsedDrugCodeOption>() { new UsedDrugCodeOption() { Key = string.Empty, Code = "No selection" } };

                usedDrugCodes.AddRange(await UsedDrugService.UsedDrugsByCodeAsync());

                return View(new OutPageIndexModel()
                {
                    Outs = outs,
                    Title = "Ins view",
                    Description = "Ins",
                    Keywords = "Ins, patients, mkb",
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
                    Title = "Out view",
                    Description = "Out",
                    Keywords = "Out, patients, mkb",
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
