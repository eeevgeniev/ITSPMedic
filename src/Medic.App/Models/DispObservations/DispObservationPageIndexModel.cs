using Medic.App.Models.Bases;
using Medic.AppModels.DispObservations;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.Sexes;
using System.Collections.Generic;

namespace Medic.App.Models.DispObservations
{
    public class DispObservationPageIndexModel : BasePageSummaryModel
    {
        public DispObservationSearch Search { get; set; }

        public List<DispObservationPreviewViewModel> DispObservations { get; set; }

        public List<HealthRegionOption> HealthRegions { get; set; }

        public List<SexOption> Sexes { get; set; }
    }
}
