using Medic.App.Models.Bases;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Outs;
using Medic.AppModels.Sexes;
using Medic.AppModels.UsedDrugs;
using System.Collections.Generic;

namespace Medic.App.Models.Outs
{
    public class OutPageIndexModel : BasePageSummaryModel
    {
        public OutSearch Search { get; set; }

        public List<OutPreviewViewModel> Outs { get; set; }

        public List<SexOption> Sexes { get; set; }

        public List<HealthRegionOption> HealthRegions { get; set; }

        public List<UsedDrugCodeOption> UsedDrugCodes { get; set; }
    }
}
