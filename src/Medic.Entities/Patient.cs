using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Patient
    /// </summary>
    [Serializable]
    public partial class Patient : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public string CountryCode { get; set; }

        public string InstitutionId { get; set; }

        public string InstitutionName { get; set; }

        public string CertificateType { get; set; }

        public DateTime? DateTo { get; set;}

        public string EhicC { get; set; }

        public string PersonalIdNumber { get; set; }

        public string Notes { get; set; }

        public string IdentityNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public int? SexId { get; set; }

        public Sex Sex { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

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