using Medic.App.Models.Bases;
using Medic.AppModels.HealthRegions;
using Medic.AppModels.InClinicProcedures;
using Medic.AppModels.Sexes;
using System.Collections.Generic;

namespace Medic.App.Models.InClinicProcedures
{
    public class InClinicProcedurePageIndexModel : BasePageSummaryModel
    {
        public InClinicProcedureSearch Search { get; set; }

        public List<InClinicProcedurePreviewViewModel> InClinicProcedures { get; set; }

        public List<HealthRegionOption> HealthRegions { get; set; }

        public List<SexOption> Sexes { get; set; }
    }
}
