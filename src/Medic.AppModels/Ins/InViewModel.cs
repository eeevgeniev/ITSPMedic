using Medic.AppModels.Diagnoses;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Ins
{
    public class InViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientBranch)]
        public string PatientBranch { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientHRegion)]
        public string PatientHRegion { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.InType)]
        public int InType { get; set; }

        public HealthcarePractitionerSummaryViewModel Sender { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendDate)]
        public DateTime SendDate { get; set; }

        public List<DiagnosePreviewViewModel> SendDiagnoses { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendUrgency)]
        public int SendUrgency { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendApr)]
        public int? SendApr { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendClinicalPath)]
        public string SendClinicalPath { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.UniqueIdentifier)]
        public string UniqueIdentifier { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ExaminationDate)]
        public DateTime ExaminationDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PlannedNumber)]
        public int PlannedNumber { get; set; }

        public List<DiagnosePreviewViewModel> Diagnoses { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Urgency)]
        public int Urgency { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.InApr)]
        public int? InApr { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ClinicalPath)]
        public string ClinicalPath { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NZOKPay)]
        public int NZOKPay { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.InMedicalWard)]
        public decimal InMedicalWard { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.EntryDate)]
        public DateTime EntryDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Severity)]
        public int Severity { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Delay)]
        public int? Delay { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Payer)]
        public int Payer { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.AgeInDays)]
        public int? AgeInDays { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.WeightInGrams)]
        public int? WeightInGrams { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.BirthWeight)]
        public int? BirthWeight { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MotherIZYear)]
        public int? MotherIZYear { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MotherIZNo)]
        public int? MotherIZNo { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IZYear)]
        public int? IZYear { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IZNo)]
        public int? IZNo { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CPFile)]
        public string CPFile { get; set; }
    }
}
