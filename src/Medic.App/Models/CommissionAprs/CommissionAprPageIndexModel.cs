using Medic.App.Models.Bases;
using Medic.AppModels.CommissionAprs;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Sexes;
using System.Collections.Generic;

namespace Medic.App.Models.CommissionAprs
{
    public class CommissionAprPageIndexModel : BasePageSummaryModel
    {
        public CommissionAprSearch Search { get; set; }

        public List<CommissionAprPreviewViewModel> CommissionAprs { get; set; }

        public List<HealthRegionOption> HealthRegions { get; set; }

        public List<SexOption> Sexes { get; set; }
    }
}
