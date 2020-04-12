using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Sender
    /// CLPR -> Sender
    /// CLPR -> Doctor
    /// CP -> Chairman
    /// CP -> Member
    /// </summary>
    [Serializable]
    public partial class HealthcarePractitioner : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? PractitionerTypeId { get; set; }

        public PractitionerType PractitionerType { get; set; }

        public int? HealthRegionId { get; set; }

        public HealthRegion HealthRegion { get; set; }

        public int? PracticeId { get; set; }

        public Practice Practice { get; set; }

        public int? SenderTypeId { get; set; }

        public SenderType SenderType { get; set; }

        public string UniqueIdentifier { get; set; }

        public string DeputyUniqueIdentifier { get; set; }

        public int? SpecialityId { get; set; }

        public SpecialtyType Speciality { get; set; }

        public int ClinicalPathNumber { get; set; }

        public string Name { get; set; }

        public ICollection<HealthcarePractitionerEpicrisis> HealthcarePractitionerEpicrisises { get; set; } = new HashSet<HealthcarePractitionerEpicrisis>();

        public ICollection<In> Ins { get; set; } = new HashSet<In>();

        public ICollection<InClinicProcedure> InClinicProcedures { get; set; } = new HashSet<InClinicProcedure>();

        public ICollection<Out> Outs { get; set; } = new HashSet<Out>();

        public ICollection<PathProcedure> PathProcedures { get; set; } = new HashSet<PathProcedure>();

        public ICollection<ProtocolDrugTherapy> ProtocolDrugTherapiesAsChairman { get; set; } = new HashSet<ProtocolDrugTherapy>();

        public ICollection<ProtocolDrugTherapyHealthPractitioner> ProtocolDrugTherapies { get; set; } = new HashSet<ProtocolDrugTherapyHealthPractitioner>();

        public ICollection<CommissionApr> CommissionAprs { get; set; } = new HashSet<CommissionApr>();

        public ICollection<CommissionApr> ChairmanOfCommissionAprs { get; set; } = new HashSet<CommissionApr>();

        public ICollection<CommissionAprHealthcarePractitioner> CommissionAprsMembers { get; set; } = new HashSet<CommissionAprHealthcarePractitioner>();

        public ICollection<DispObservation> DispObservations { get; set; } = new HashSet<DispObservation>();

        public ICollection<DispObservation> DoctorDispObservations { get; set; } = new HashSet<DispObservation>();

        public ICollection<DoneProcedure> DoneProcedures { get; set; } = new HashSet<DoneProcedure>();

        public ICollection<PlannedProcedure> PlannedProcedures { get; set; } = new HashSet<PlannedProcedure>();
    }
}
