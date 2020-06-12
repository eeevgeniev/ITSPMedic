using Medic.AppModels.CeasedClinicals;
using Medic.AppModels.Diags;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.InClinicProcedures
{
    public class InClinicProcedureViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = nameof(PatientBranch))]
        public string PatientBranch { get; set; }

        [Display(Name = "PatientHRegion")]
        public string PatientHealthRegion { get; set; }

        public HealthcarePractitionerSummaryViewModel Sender { get; set; }

        [Display(Name = nameof(CPrSend))]
        public double? CPrSend { get; set; }

        [Display(Name = nameof(APrSend))]
        public double? APrSend { get; set; }

        [Display(Name = nameof(TypeProcSend))]
        public int TypeProcSend { get; set; }

        [Display(Name = nameof(DateSend))]
        public DateTime DateSend { get; set; }

        [Display(Name = nameof(CPrPriem))]
        public double? CPrPriem { get; set; }

        [Display(Name = nameof(APrPriem))]
        public double? APrPriem { get; set; }

        [Display(Name = nameof(TypeProcPriem))]
        public int TypeProcPriem { get; set; }

        [Display(Name = nameof(ProcRefuse))]
        public int ProcRefuse { get; set; }

        public CeasedClinicalViewModel CeasedClinicalPath { get; set; }

        [Display(Name = nameof(IZNumChild))]
        public int? IZNumChild { get; set; }

        [Display(Name = nameof(IZYearChild))]
        public int IZYearChild { get; set; }

        [Display(Name = nameof(FirstVisitDate))]
        public DateTime? FirstVisitDate { get; set; }

        [Display(Name = nameof(PlanVisitDate))]
        public DateTime? PlanVisitDate { get; set; }

        [Display(Name = nameof(VisitDocumentUniqueIdentifier))]
        public string VisitDocumentUniqueIdentifier { get; set; }

        [Display(Name = nameof(VisitDocumentName))]
        public string VisitDocumentName { get; set; }

        public DiagPreviewViewModel FirstMainDiag { get; set; }

        public DiagPreviewViewModel SecondMainDiag { get; set; }

        [Display(Name = nameof(PatientStatus))]
        public int PatientStatus { get; set; }

        [Display(Name = nameof(NZOKPay))]
        public int NZOKPay { get; set; }
    }
}