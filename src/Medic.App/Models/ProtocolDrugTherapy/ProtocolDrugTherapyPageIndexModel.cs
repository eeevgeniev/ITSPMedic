using Medic.App.Models.Bases;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.ProtocolDrugTherapies;
using Medic.AppModels.Sexes;
using System.Collections.Generic;

namespace Medic.App.Models.ProtocolDrugTherapy
{
    public class ProtocolDrugTherapyPageIndexModel : BasePageSummaryModel
    {
        public ProtocolDrugTherapySearch Search { get; set; }

        public List<ProtocolDrugTherapyPreviewViewModel> ProtocolDrugTherapies { get; set; }

        public List<HealthRegionOption> HealthRegions { get; set; }

        public List<SexOption> Sexes { get; set; }

        public List<string> ATCNames { get; set; }
    }
}
