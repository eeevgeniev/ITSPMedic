using Medic.App.Models.Bases;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.PathProcedures;
using Medic.AppModels.Sexes;
using System.Collections.Generic;

namespace Medic.App.Models.PathProcedures
{
    public class PathProcedurePageIndexModel : BasePageSummaryModel
    {
        public PathProcedureSearch Search { get; set; }

        public List<PathProcedurePreviewViewModel> PathProcedures { get; set; }

        public List<HealthRegionOption> HealthRegions { get; set; }

        public List<SexOption> Sexes { get; set; }

        public List<string> UsedDrugCodes { get; set; }
    }
}
