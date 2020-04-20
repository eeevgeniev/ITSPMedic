using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> DoneProcedure
    /// </summary>
    [Serializable]
    public partial class DoneProcedure : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public DateTime? ProcedureStartDate { get; set; }

        public DateTime? ProcedureEndDate { get; set; }

        public int? DoctorId { get; set; }

        public HealthcarePractitioner Doctor { get; set; }

        public int? PathProcedureId { get; set; }

        public PathProcedure PathProcedure { get; set; }
    }
}
