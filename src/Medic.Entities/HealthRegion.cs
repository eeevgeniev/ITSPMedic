using AutoMapper;
using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    [Serializable]
    public partial class HealthRegion : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Code { get; set; }

        public Practice Practice { get; set; }

        public ICollection<HospitalPractice> HospitalPractices { get; set; } = new HashSet<HospitalPractice>();

        public ICollection<In> Ins { get; set; } = new HashSet<In>();

        public ICollection<InClinicProcedure> InClinicProcedures { get; set; } = new HashSet<InClinicProcedure>();

        public ICollection<Out> Outs { get; set; } = new HashSet<Out>();

        public ICollection<PathProcedure> PathProcedures { get; set; } = new HashSet<PathProcedure>();

        public ICollection<ProtocolDrugTherapy> ProtocolDrugTherapies { get; set; } = new HashSet<ProtocolDrugTherapy>();

        public ICollection<HealthcarePractitioner> HealthcarePractitioners { get; set; } = new HashSet<HealthcarePractitioner>();

        public ICollection<CommissionApr> CommissionAprs { get; set; } = new HashSet<CommissionApr>();

        public ICollection<DispObservation> DispObservations { get; set; } = new HashSet<DispObservation>();

        public ICollection<PlannedProcedure> PlannedProcedures { get; set; } = new HashSet<PlannedProcedure>();

        public ICollection<PatientBranch> PatientBranches { get; set; } = new HashSet<PatientBranch>();
    }
}