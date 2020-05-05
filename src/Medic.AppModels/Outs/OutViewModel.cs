using Medic.AppModels.Diagnoses;
using Medic.AppModels.Epicrisises;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.HistologicalResult;
using Medic.AppModels.Patients;
using Medic.AppModels.Procedures;
using Medic.AppModels.UsedDrugs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Outs
{
    public class OutViewModel
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
        public double SendClinicalPath { get; set; }

        [Display(Name = nameof(UniqueIdentifier))]
        public string UniqueIdentifier { get; set; }

        [Display(Name = nameof(ExaminationDate))]
        public DateTime ExaminationDate { get; set; }

        public List<DiagnosePreviewViewModel> Diagnoses { get; set; }

        [Display(Name = nameof(Urgency))]
        public int Urgency { get; set; }

        [Display(Name = nameof(ClinicalPath))]
        public double ClinicalPath { get; set; }

        [Display(Name = nameof(NZOKPay))]
        public int NZOKPay { get; set; }

        [Display(Name = nameof(InMedicalWard))]
        public decimal InMedicalWard { get; set; }

        [Display(Name = nameof(EntryDate))]
        public DateTime EntryDate { get; set; }

        [Display(Name = nameof(Severity))]
        public int Severity { get; set; }

        [Display(Name = nameof(Delay))]
        public int Delay { get; set; }

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

        [Display(Name = nameof(OutMedicalWard))]
        public decimal OutMedicalWard { get; set; }

        [Display(Name = nameof(OutUniqueIdentifier))]
        public string OutUniqueIdentifier { get; set; }

        [Display(Name = nameof(OutDate))]
        public DateTime OutDate { get; set; }

        [Display(Name = nameof(OutType))]
        public int OutType { get; set; }

        public DiagnosePreviewViewModel Dead { get; set; }

        [Display(Name = nameof(BirthPractice))]
        public string BirthPractice { get; set; }

        [Display(Name = nameof(BirthNumber))]
        public int? BirthNumber { get; set; }

        [Display(Name = nameof(BirthGestWeek))]
        public int? BirthGestWeek { get; set; }

        [Display(Name = nameof(OutClinicalPath))]
        public double OutClinicalPath { get; set; }

        [Display(Name = nameof(OutAPr))]
        public string OutAPr { get; set; }

        public HistologicalResultSummaryViewModel HistologicalResult { get; set; }

        public EpicrisisSummaryViewModel Epicrisis { get; set; }

        public DiagnosePreviewViewModel OutMainDiagnose { get; set; }

        public List<DiagnosePreviewViewModel> OutDiagnoses { get; set; }

        public UsedDrugSummaryViewModel UsedDrug { get; set; }

        public List<ProcedureSummaryViewModel> Procedures { get; set; }

        [Display(Name = nameof(BedDays))]
        public int? BedDays { get; set; }

        [Display(Name = nameof(HLDateFrom))]
        public DateTime? HLDateFrom { get; set; }

        [Display(Name = nameof(HLNumber))]
        public string HLNumber { get; set; }

        [Display(Name = nameof(HLTotalDays))]
        public int? HLTotalDays { get; set; }

        [Display(Name = nameof(StateAtDischarge))]
        public int? StateAtDischarge { get; set; }

        [Display(Name = nameof(Laparoscopic))]
        public int? Laparoscopic { get; set; }

        [Display(Name = nameof(EndCourse))]
        public int? EndCourse { get; set; }

        [Display(Name = nameof(CPFile))]
        public string CPFile { get; set; }
    }
}