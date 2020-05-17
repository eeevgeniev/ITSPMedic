using Medic.AppModels.Diagnoses;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.PlannedProcedures
{
    public class PlannedProcedureViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = nameof(PatientBranch))]
        public string PatientBranch { get; set; }

        [Display(Name = nameof(PatientHRegion))]
        public string PatientHRegion { get; set; }

        [Display(Name = nameof(InType))]
        public int InType { get; set; }

        public HealthcarePractitionerSummaryViewModel Sender { get; set; }

        [Display(Name = nameof(SendDate))]
        public DateTime SendDate { get; set; }

        public DiagnosePreviewViewModel SendDiagnose { get; set; }

        [Display(Name = nameof(SendUrgency))]
        public int SendUrgency { get; set; }

        [Display(Name = nameof(SendClinicalPath))]
        public double? SendClinicalPath { get; set; }

        [Display(Name = nameof(UniqueIdentifier))]
        public string UniqueIdentifier { get; set; }

        [Display(Name = nameof(ExaminationDate))]
        public DateTime ExaminationDate { get; set; }

        [Display(Name = nameof(PlannedEntryDate))]
        public DateTime PlannedEntryDate { get; set; }

        [Display(Name = nameof(PlannedNumber))]
        public int PlannedNumber { get; set; }

        public DiagnosePreviewViewModel Diagnose { get; set; }

        [Display(Name = nameof(Urgency))]
        public int Urgency { get; set; }

        [Display(Name = nameof(ClinicalPath))]
        public double? ClinicalPath { get; set; }

        [Display(Name = nameof(NZOKPay))]
        public int NZOKPay { get; set; }
    }
}
