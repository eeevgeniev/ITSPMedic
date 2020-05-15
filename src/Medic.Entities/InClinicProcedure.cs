using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> InClinicProcedure
    /// </summary>
    [Serializable]
    public partial class InClinicProcedure : BaseEntity, IModelBuilder, IModelTransformer
    {
        public int Id { get; set; }

        public int? PatientId { get; set; }

        public Patient Patient { get; set; }

        public int? PatientBranchId { get; set; }

        public PatientBranch PatientBranch { get; set; }

        public int? PatientHealthRegionId { get; set; }

        public HealthRegion PatientHealthRegion { get; set; }

        public int? SenderId { get; set; }

        public HealthcarePractitioner Sender { get; set; }

        public double? CPrSend { get; set; }

        public double? APrSend { get; set; }

        public int TypeProcSend { get; set; }

        public DateTime DateSend { get; set; }

        public double? CPrPriem { get; set; }

        public double? APrPriem { get; set; }

        public int TypeProcPriem { get; set; }

        public int ProcRefuse { get; set; }

        public int? CeasedClinicalPathId { get; set; }

        public CeasedClinicalPath CeasedClinicalPath { get; set; }

        public int? IZNumChild { get; set; }

        public int IZYearChild { get; set; }

        public DateTime? FirstVisitDate { get; set; }

        public DateTime? PlanVisitDate { get; set; }

        public string VisitDocumentUniqueIdentifier { get; set; }

        public string VisitDocumentName { get; set; }

        public int? FirstMainDiagId { get; set; }

        public Diag FirstMainDiag { get; set; }

        public int? SecondMainDiagId { get; set; }

        public Diag SecondMainDiag { get; set; }

        public int PatientStatus { get; set; }

        public int NZOKPay { get; set; }

        public int? HospitalPracticeId { get; set; }

        public HospitalPractice HospitalPractice { get; set; }
    }
}