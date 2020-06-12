using Medic.App.Models.Bases;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Plannings;
using Medic.AppModels.Sexes;
using System.Collections.Generic;

namespace Medic.App.Models.Plannings
{
    public class PlannedPageIndexModel : BasePageSummaryModel
    {
        public PlannedSearch Search { get; set; }

        public List<PlannedPreviewViewModel> Plannings { get; set; }

        public List<HealthRegionOption> HealthRegions { get; set; }

        public List<SexOption> Sexes { get; set; }
    }
}
