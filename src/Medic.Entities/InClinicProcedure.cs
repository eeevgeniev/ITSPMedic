using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

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

        public string CPrSend { get; set; }

        public string APrSend { get; set; }

        public int? TypeProcSend { get; set; }

        public int? SendPackageType { get; set; }

        public DateTime DateSend { get; set; }

        public string CPrPriem { get; set; }

        public string APrPriem { get; set; }

        public int? TypeProcPriem { get; set; }

        public int? PackageType { get; set; }

        public int ProcRefuse { get; set; }

        public int? CeasedClinicalPathId { get; set; }

        public CeasedClinical CeasedClinicalPath { get; set; }

        public int? CeasedProcedureId { get; set; }

        public CeasedClinical CeasedProcedure { get; set; }

        public int? CeasedOnlyId { get; set; }

        public CeasedClinical CeasedOnly { get; set; }

        public int? IZNumChild { get; set; }

        public int IZYearChild { get; set; }

        public DateTime? FirstVisitDate { get; set; }

        public DateTime? PlanVisitDate { get; set; }

        public int? PlannedNumber { get; set; }

        public string VisitDoctorUniqueIdentifier { get; set; }

        public string VisitDoctorName { get; set; }

        public int? FirstMainDiagId { get; set; }

        public Diag FirstMainDiag { get; set; }

        public int? SecondMainDiagId { get; set; }

        public Diag SecondMainDiag { get; set; }

        public ICollection<ClinicProcedure> Procedures { get; set; } = new HashSet<ClinicProcedure>();

        public int PatientStatus { get; set; }

        public int NZOKPay { get; set; }

        public int? HospitalPracticeId { get; set; }

        public HospitalPractice HospitalPractice { get; set; }
    }
}