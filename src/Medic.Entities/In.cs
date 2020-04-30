using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> In
    /// </summary>
    [Serializable]
    public partial class In : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? PatientId { get; set; }

        public Patient Patient { get; set; }

        public int? PatientBranchId { get; set; }

        public PatientBranch PatientBranch { get; set; }

        public int? PatientHRegionId { get; set; }

        public HealthRegion PatientHRegion { get; set; }

        public int InType { get; set; }

        public int? SenderId { get; set; }

        public HealthcarePractitioner Sender { get; set; }

        public DateTime SendDate { get; set; }

        public int? SendDiagnoseId { get; set; }

        public Diagnose SendDiagnose { get; set; }

        public int SendUrgency { get; set; }

        public int? SendApr { get; set; }

        public string SendClinicalPath { get; set; }

        public string UniqueIdentifier { get; set; }

        public DateTime ExaminationDate { get; set; }

        public int PlannedNumber { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; } = new HashSet<Diagnose>();

        public int Urgency { get; set; }

        public int? InApr { get; set; }

        public string ClinicalPath { get; set; }

        public int NZOKPay { get; set; }

        public decimal InMedicalWard { get; set; }

        public DateTime EntryDate { get; set; }

        public int Severity { get; set; }

        public int Delay { get; set; }

        public int Payer { get; set; }

        public int AgeInDays { get; set; }

        public int WeightInGrams { get; set; }

        public int BirthWeight { get; set; }

        public int MotherIZYear { get; set; }

        public int MotherIZNo { get; set; }

        public int IZYear { get; set; }

        public int IZNo { get; set; }

        public int? CPFileId { get; set; }

        public CPFile CPFile { get; set; }
    }
}
