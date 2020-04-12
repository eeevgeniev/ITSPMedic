using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> HospitalPractice
    /// </summary>
    [Serializable]
    public partial class HospitalPractice : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? HealthRegionId { get; set; }

        public HealthRegion HealthRegion { get; set; }

        public int PracticeId { get; set; }

        public Practice Practice { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int FileTypeId { get; set; }

        public FileType FileType { get; set; }

        //public string FileType { get; set; }

        public ICollection<InClinicProcedure> InClinicProcedures { get; set; } = new HashSet<InClinicProcedure>();

        public ICollection<PathProcedure> PathProcedures { get; set; } = new HashSet<PathProcedure>();

        public ICollection<DispObservation> DispObservations { get; set; } = new HashSet<DispObservation>();

        public ICollection<CommissionApr> CommissionAprs { get; set; } = new HashSet<CommissionApr>();

        public ICollection<ProtocolDrugTherapy> ProtocolDrugTherapies { get; set; } = new HashSet<ProtocolDrugTherapy>();

        public ICollection<PatientTransfer> PatientTransfers { get; set; } = new HashSet<PatientTransfer>();
    }
}