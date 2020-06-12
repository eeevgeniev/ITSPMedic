using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> Planned
    /// </summary>
    [Serializable]
    public partial class Planned : BaseEntity, IModelBuilder, IModelTransformer
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

        public ICollection<Diagnose> SendDiagnoses { get; set; } = new HashSet<Diagnose>();

        public int SendUrgency { get; set; }

        public int? SendPackageType { get; set; }

        public double? SendClinicalPath { get; set; }

        public int? SendAPr { get; set; }

        public string UniqueIdentifier { get; set; }

        public DateTime ExaminationDate { get; set; }

        public DateTime PlannedEntryDate { get; set; }

        public int PlannedNumber { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; } = new HashSet<Diagnose>();

        public int Urgency { get; set; }

        public int? PackageType { get; set; }

        public double? ClinicalPath { get; set; }

        public int? InAPr { get; set; }

        public int NZOKPay { get; set; }

        public int CPFileId { get; set; } 

        public CPFile CPFile { get; set; }
    }
}