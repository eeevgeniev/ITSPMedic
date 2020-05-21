using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> DispObservation
    /// </summary>
    [Serializable]
    public partial class DispObservation : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? PatientId { get; set; }

        public Patient Patient { get; set; }

        public int? PatientBranchId { get; set; }

        public PatientBranch PatientBranch { get; set; }

        public int? PatientHRegionId { get; set; }

        public HealthRegion PatientHRegion { get; set; }

        public int? DoctorId { get; set; }
        
        public HealthcarePractitioner Doctor { get; set; }

        public int DispNum { get; set; }

        public DateTime DispDate { get; set; }

        public string AprCode { get; set; }

        public DateTime DiagDate { get; set; }

        public DateTime? DispanserDate { get; set; }

        public int DispVisit { get; set; }

        public ICollection<MDI> MDIs { get; set; } = new HashSet<MDI>();

        public int? MainDiagFirstId { get; set; } 

        public Diag FirstMainDiag { get; set; }

        public int? MainDiagSecondId { get; set; } 

        public Diag SecondMainDiag { get; set; }

        public int? HospitalPracticeId { get; set; }

        public HospitalPractice HospitalPractice { get; set; }

        public string Anamnesa { get; set; }

        public string HState { get; set; }

        public string Therapy { get; set; }

        public int Sign { get; set; }

        public int NZOKPay { get; set; }
    }
}