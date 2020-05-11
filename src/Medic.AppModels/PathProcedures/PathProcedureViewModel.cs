using Medic.AppModels.CeasedClinicalPaths;
using Medic.AppModels.ClinicProcedures;
using Medic.AppModels.ClinicUsedDrugs;
using Medic.AppModels.Diags;
using Medic.AppModels.DoneProcedures;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using Medic.AppModels.Procedures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.PathProcedures
{
    public class PathProcedureViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = nameof(PatientBranch))]
        public string PatientBranch { get; set; }

        [Display(Name = nameof(PatientHRegion))]
        public string PatientHRegion { get; set; }

        public HealthcarePractitionerSummaryViewModel Sender { get; set; }

        [Display(Name = nameof(CPrSend))]
        public double? CPrSend { get; set; }

        [Display(Name = nameof(APrSend))]
        public decimal? APrSend { get; set; }

        [Display(Name = nameof(TypeProcSend))]
        public int TypeProcSend { get; set; }

        [Display(Name = nameof(DateSend))]
        public DateTime DateSend { get; set; }

        [Display(Name = nameof(CPrPriem))]
        public double? CPrPriem { get; set; }

        [Display(Name = nameof(APrPriem))]
        public decimal? APrPriem { get; set; }

        [Display(Name = nameof(MedicalWard))]
        public decimal MedicalWard { get; set; }

        [Display(Name = nameof(TypeProcPriem))]
        public int TypeProcPriem { get; set; }

        [Display(Name = nameof(ProcRefuse))]
        public int ProcRefuse { get; set; }

        public CeasedClinicalPathViewModel CeasedProcedure { get; set; }

        public CeasedClinicalPathViewModel CeasedClinicalPath { get; set; }

        [Display(Name = nameof(IZNumChild))]
        public string IZNumChild { get; set; }

        [Display(Name = nameof(IZYearChild))]
        public int IZYearChild { get; set; }

        [Display(Name = nameof(FirstVisitDate))]
        public DateTime? FirstVisitDate { get; set; }

        [Display(Name = nameof(DatePlanPriem))]
        public DateTime? DatePlanPriem { get; set; }

        [Display(Name = nameof(VisitDocumentUniqueIdentifier))]
        public string VisitDocumentUniqueIdentifier { get; set; }

        [Display(Name = nameof(VisitDocumentName))]
        public string VisitDocumentName { get; set; }

        public DiagPreviewViewModel FirstMainDiag { get; set; }

        public DiagPreviewViewModel SecondMainDiag { get; set; }

        [Display(Name = nameof(DateProcedureBegins))]
        public DateTime? DateProcedureBegins { get; set; }

        [Display(Name = nameof(DateProcedureEnd))]
        public DateTime? DateProcedureEnd { get; set; }

        public List<ProcedureSummaryViewModel> DoneNewProcedures { get; set; }

        public ClinicUsedDrugViewModel UsedDrug { get; set; }

        public List<ClinicProcedureViewModel> ClinicProcedures { get; set; }

        public List<DoneProcedureViewModel> DoneProcedures { get; set; }

        [Display(Name = nameof(AllDoneProcedures))]
        public decimal AllDoneProcedures { get; set; }

        [Display(Name = nameof(AllDoneCost))]
        public decimal AllDoneCost { get; set; }

        [Display(Name = nameof(PatientStatus))]
        public int PatientStatus { get; set; }

        [Display(Name = nameof(OutUniqueIdentifier))]
        public string OutUniqueIdentifier { get; set; }

        [Display(Name = nameof(Sign))]
        public int Sign { get; set; }

        [Display(Name = nameof(NZOKPay))]
        public int NZOKPay { get; set; }
    }
}
