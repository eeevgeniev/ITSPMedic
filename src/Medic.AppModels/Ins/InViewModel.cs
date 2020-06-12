using Medic.AppModels.Diagnoses;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Ins
{
    public class InViewModel
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

        public List<DiagnosePreviewViewModel> SendDiagnoses { get; set; }

        [Display(Name = nameof(SendUrgency))]
        public int SendUrgency { get; set; }

        [Display(Name = nameof(SendApr))]
        public int? SendApr { get; set; }

        [Display(Name = nameof(SendClinicalPath))]
        public string SendClinicalPath { get; set; }

        [Display(Name = nameof(UniqueIdentifier))]
        public string UniqueIdentifier { get; set; }

        [Display(Name = nameof(ExaminationDate))]
        public DateTime ExaminationDate { get; set; }

        [Display(Name = nameof(PlannedNumber))]
        public int PlannedNumber { get; set; }

        public List<DiagnosePreviewViewModel> Diagnoses { get; set; }

        [Display(Name = nameof(Urgency))]
        public int Urgency { get; set; }

        [Display(Name = nameof(InApr))]
        public int? InApr { get; set; }

        [Display(Name = nameof(ClinicalPath))]
        public string ClinicalPath { get; set; }

        [Display(Name = nameof(NZOKPay))]
        public int NZOKPay { get; set; }

        [Display(Name = nameof(InMedicalWard))]
        public decimal InMedicalWard { get; set; }

        [Display(Name = nameof(EntryDate))]
        public DateTime EntryDate { get; set; }

        [Display(Name = nameof(Severity))]
        public int Severity { get; set; }

        [Display(Name = nameof(Delay))]
        public int? Delay { get; set; }

        [Display(Name = nameof(Payer))]
        public int Payer { get; set; }

        [Display(Name = nameof(AgeInDays))]
        public int? AgeInDays { get; set; }

        [Display(Name = nameof(WeightInGrams))]
        public int? WeightInGrams { get; set; }

        [Display(Name = nameof(BirthWeight))]
        public int? BirthWeight { get; set; }

        [Display(Name = nameof(MotherIZYear))]
        public int? MotherIZYear { get; set; }

        [Display(Name = nameof(MotherIZNo))]
        public int? MotherIZNo { get; set; }

        [Display(Name = nameof(IZYear))]
        public int? IZYear { get; set; }

        [Display(Name = nameof(IZNo))]
        public int? IZNo { get; set; }

        [Display(Name = nameof(CPFile))]
        public string CPFile { get; set; }
    }
}
