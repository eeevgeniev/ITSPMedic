using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    [Serializable]
    public partial class PatientBranch : BaseEntity, IModelBuilder
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public ICollection<In> Ins { get; set; } = new HashSet<In>();

        public ICollection<InClinicProcedure> InClinicProcedures { get; set; } = new HashSet<InClinicProcedure>();

        public ICollection<Out> Outs { get; set; } = new HashSet<Out>();

        public ICollection<PathProcedure> PathProcedures { get; set; } = new HashSet<PathProcedure>();

        public ICollection<ProtocolDrugTherapy> ProtocolDrugTherapies { get; set; } = new HashSet<ProtocolDrugTherapy>();

        public ICollection<CommissionApr> CommissionAprs { get; set; } = new HashSet<CommissionApr>();

        public ICollection<DispObservation> DispObservations { get; set; } = new HashSet<DispObservation>();

        public ICollection<PlannedProcedure> PlannedProcedures { get; set; } = new HashSet<PlannedProcedure>();
    }
}