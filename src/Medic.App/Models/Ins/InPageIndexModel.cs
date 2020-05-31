using Medic.App.Models.Bases;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Ins;
using Medic.AppModels.Sexes;
using System.Collections.Generic;

namespace Medic.App.Models.Ins
{
    public class InPageIndexModel : BasePageSummaryModel
    {
        public InsSearch Search { get; set; }

        public List<InPreviewViewModel> Ins { get; set; }

        public List<HealthRegionOption> HealthRegions { get; set; }

        public List<SexOption> Sexes { get; set; }
    }
}