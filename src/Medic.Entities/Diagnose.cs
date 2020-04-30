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

        public In In { get; set; }

        public int? MainInId { get; set; }

        public In MainIn { get; set; }

        public Out SendOut { get; set; }

        public int? OutId { get; set; }

        public Out Out { get; set; }

        public Out OutDead { get; set; }

        public Out OutMain { get; set; }

        public int? OutOutId { get; set; }

        public Out OutOut { get; set; }

        public PlannedProcedure SendPlannedProcedure { get; set; }

        public PlannedProcedure PlannedProcedure { get; set; }
    }
}