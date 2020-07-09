using Medic.AppModels.CeasedClinicals;
using Medic.AppModels.Diags;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.InClinicProcedures
{
    public class InClinicProcedureViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientBranch)]
        public string PatientBranch { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientHRegion)]
        public string PatientHealthRegion { get; set; }

        public HealthcarePractitionerSummaryViewModel Sender { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CPrSend)]
        public double? CPrSend { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.APrSend)]
        public double? APrSend { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.TypeProcSend)]
        public int TypeProcSend { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DateSend)]
        public DateTime DateSend { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CPrPriem)]
        public double? CPrPriem { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.APrPriem)]
        public double? APrPriem { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.TypeProcPriem)]
        public int TypeProcPriem { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProcRefuse)]
        public int ProcRefuse { get; set; }

        public CeasedClinicalViewModel CeasedClinicalPath { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IZNumChild)]
        public int? IZNumChild { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IZYearChild)]
        public int IZYearChild { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FirstVisitDate)]
        public DateTime? FirstVisitDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PlanVisitDate)]
        public DateTime? PlanVisitDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.VisitDocumentUniqueIdentifier)]
        public string VisitDocumentUniqueIdentifier { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.VisitDocumentName)]
        public string VisitDocumentName { get; set; }

        public DiagPreviewViewModel FirstMainDiag { get; set; }

        public DiagPreviewViewModel SecondMainDiag { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientStatus)]
        public int PatientStatus { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NZOKPay)]
        public int NZOKPay { get; set; }
    }
}