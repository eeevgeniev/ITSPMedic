using Medic.App.Models.Bases;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.PlannedProcedures;
using Medic.AppModels.Sexes;
using System.Collections.Generic;

namespace Medic.App.Models.PlannedProcedures
{
    public class PlannedProcedurePageIndexModel : BasePageSummaryModel
    {
        public PlannedProcedureSearch Search { get; set; }

        public List<PlannedProcedurePreviewViewModel> PlannedProcedures { get; set; }

        public List<HealthRegionOption> HealthRegions { get; set; }

        public List<SexOption> Sexes { get; set; }
    }
}
