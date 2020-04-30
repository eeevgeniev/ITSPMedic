using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> CommissionApr
    /// </summary>
    [Serializable]
    public partial class CommissionApr : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? PatientId { get; set; }

        public Patient Patient { get; set; }

        public int? PatientBranchId { get; set; }

        public PatientBranch PatientBranch { get; set; }

        public int? PatientHRegionId { get; set; }

        public HealthRegion PatientHRegion { get; set; }

        public int? SenderId { get; set; }

        public HealthcarePractitioner Sender { get; set; }

        public double? AprSend { get; set; }

        public DateTime SendDate { get; set; }

        public double? AprPriem { get; set; }

        public int SpecCommission { get; set; }

        public int NoDecision { get; set; }

        public DateTime DecisionDate { get; set; }

        public int? ChairmanId { get; set; }

        public HealthcarePractitioner Chairman { get; set; }

        public ICollection<CommissionAprHealthcarePractitioner> Members { get; set; } = new HashSet<CommissionAprHealthcarePractitioner>();

        public int? MainDiagId { get; set;  }

        public Diag MainDiag { get; set; }

        public int? HospitalPracticeId { get; set; }

        public HospitalPractice HospitalPractice { get; set; }

        public ICollection<Diag> AddDiag { get; set; } = new HashSet<Diag>();

        public int? APr38Id { get; set; }

        public APr38 APr38 { get; set; }

        public int? APr05Id { get; set; }

        public APr05 APr05 { get; set; }

        public int Sign { get; set; }

        public int NZOKPay { get; set; }
    }
}
