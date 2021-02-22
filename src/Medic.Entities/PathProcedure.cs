using Medic.Entities.Bases;
using Medic.Entities.Contracts;
using Medic.Mappers.Contracts;
using System;
using System.Collections.Generic;

namespace Medic.Entities
{
    /// <summary>
    /// CLPR -> PathProcedur
    /// </summary>
    [Serializable]
    public partial class PathProcedure : BaseEntity, IModelBuilder, IModelTransformer
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

        public string CPrSend { get; set; }

        public string APrSend { get; set; }

        public int TypeProcSend { get; set; }

        public int? SendPackageType { get; set; }

        public DateTime DateSend { get; set; }

        public string CPrPriem { get; set; }

        public string APrPriem { get; set; }

        public string MedicalWard { get; set; }

        public string BirthPractice { get; set; }

        public int? BirthNumber { get; set; }

        public int? BirthGestWeek { get; set; }

        public int TypeProcPriem { get; set; }

        public int? PackageType { get; set; }

        public int ProcRefuse { get; set; }

        public int? CeasedProcedureId { get; set; }

        public CeasedClinical CeasedProcedure { get; set; }

        public int? CeasedClinicalPathId { get; set; }

        public CeasedClinical CeasedClinicalPath { get; set; }

        public int? CeasedOnlyId { get; set; }

        public CeasedClinical CeasedOnly { get; set; }

        public string IZNumChild { get; set; }

        public int IZYearChild { get; set; }

        public DateTime? FirstVisitDate { get; set; }

        public DateTime? DatePlanPriem { get; set; }

        public int? PlannedNumber { get; set; }

        public string VisitDoctorUniqueIdentifier { get; set; }

        public string VisitDoctorName { get; set; }

        public int? FirstMainDiagId { get; set; }

        public Diag FirstMainDiag { get; set; }

        public int? SecondMainDiagId { get; set; }

        public Diag SecondMainDiag { get; set; }

        public DateTime? DateProcedureBegins { get; set; }

        public DateTime? DateProcedureEnd { get; set; }

        public ICollection<Procedure> DoneNewProcedures { get; set; } = new HashSet<Procedure>();

        public ICollection<ClinicUsedDrug> UsedDrugs { get; set; } = new HashSet<ClinicUsedDrug>();

        public ICollection<ClinicProcedure> ClinicProcedures { get; set; } = new HashSet<ClinicProcedure>();

        public ICollection<DoneProcedure> DoneProcedures { get; set; } = new HashSet<DoneProcedure>();

        public int? AllDoneProcedures { get; set; }

        public int? AllDays { get; set; }

        public decimal? AllDrugCost { get; set; }

        public string RedirectedClinicalPath { get; set; }

        public int PatientStatus { get; set; }

        public string RedirectedProc { get; set; }

        public int? EndCourse { get; set; }

        public string OutUniqueIdentifier { get; set; }

        public int Sign { get; set; }

        public int NZOKPay { get; set; }

        public int? HospitalPracticeId { get; set; }

        public HospitalPractice HospitalPractice { get; set; }
    }
}