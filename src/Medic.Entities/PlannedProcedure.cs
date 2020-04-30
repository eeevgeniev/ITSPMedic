using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CP -> PlannedProcedure
    /// </summary>
    [Serializable]
    public partial class PlannedProcedure : BaseEntity, IModelBuilder, IModelTransformer
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

        public double? SendClinicalPath { get; set; }

        public string UniqueIdentifier { get; set; }

        public DateTime ExaminationDate { get; set; }

        public DateTime PlannedEntryDate { get; set; }

        public int PlannedNumber { get; set; }

        public int? DiagnoseId { get; set; } 

        public Diagnose Diagnose { get; set; }

        public int Urgency { get; set; }

        public double? ClinicalPath { get; set; }

        public int NZOKPay { get; set; }

        public int CPFileId { get; set; } 

        public CPFile CPFile { get; set; }
    }
}