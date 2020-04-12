using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Diagnose
    /// CP -> SendDiagnose
    /// CP -> Dead
    /// CP -> OutMainDiagnose
    /// CP -> OutDiagnose
    /// </summary>
    [Serializable]
    public partial class Diagnose : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public string PrimaryCode { get; set; }

        public MKB Primary { get; set; }

        public string SecondaryCode { get; set; }

        public MKB Secondary { get; set; }

        public In In { get; set; } // added

        public int? MainInId { get; set; } // added

        public In MainIn { get; set; }

        public Out SendOut { get; set; } // added

        public int? OutId { get; set; }

        public Out Out { get; set; } //added

        public Out OutDead { get; set; } // added

        public Out OutMain { get; set; } // added

        public int? OutOutId { get; set; }

        public Out OutOut { get; set; } // added

        public PlannedProcedure SendPlannedProcedure { get; set; } //added

        public PlannedProcedure PlannedProcedure { get; set; } // added
    }
}