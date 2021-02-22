using Medic.AppModels.Diagnoses;
using Medic.AppModels.Epicrisises;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.HistologicalResult;
using Medic.AppModels.Patients;
using Medic.AppModels.Procedures;
using Medic.AppModels.UsedDrugs;
using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Outs
{
    public class OutViewModel
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

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendClinicalPath)]
        public string SendClinicalPath { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendApr)]
        public string SendAPr { get; set; }
        
        [Display(Name = MedicDataAnnotationLocalizerProvider.PlannedNumber)]
        public int? PlannedNumber { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.InApr)]
        public string InAPr { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.UniqueIdentifier)]
        public string UniqueIdentifier { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ExaminationDate)]
        public DateTime ExaminationDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PlannedEntryDate)]
        public DateTime? PlannedEntryDate { get; set; }

        public List<DiagnosePreviewViewModel> Diagnoses { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Urgency)]
        public int Urgency { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PackageType)]
        public int? PackageType { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ClinicalPath)]
        public string ClinicalPath { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SendPackageType)]
        public int? SendPackageType { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NZOKPay)]
        public int NZOKPay { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.InMedicalWard)]
        public string InMedicalWard { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.EntryDate)]
        public DateTime EntryDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Severity)]
        public int? Severity { get; set; }

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

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutMedicalWard)]
        public string OutMedicalWard { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutUniqueIdentifier)]
        public string OutUniqueIdentifier { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutDate)]
        public DateTime OutDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutType)]
        public int OutType { get; set; }

        public DiagnosePreviewViewModel Dead { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.BirthPractice)]
        public string BirthPractice { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.BirthNumber)]
        public int? BirthNumber { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.BirthGestWeek)]
        public int? BirthGestWeek { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutClinicalPath)]
        public string OutClinicalPath { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutAPr)]
        public string OutAPr { get; set; }

        public HistologicalResultSummaryViewModel HistologicalResult { get; set; }

        public EpicrisisSummaryViewModel Epicrisis { get; set; }

        public DiagnosePreviewViewModel OutMainDiagnose { get; set; }

        public List<DiagnosePreviewViewModel> OutDiagnoses { get; set; }

        public List<UsedDrugSummaryViewModel> UsedDrugs { get; set; }

        public List<ProcedureSummaryViewModel> Procedures { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.BedDays)]
        public int? BedDays { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.HLDateFrom)]
        public DateTime? HLDateFrom { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.HLNumber)]
        public string HLNumber { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.HLTotalDays)]
        public int? HLTotalDays { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.StateAtDischarge)]
        public int? StateAtDischarge { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Laparoscopic)]
        public int? Laparoscopic { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.EndCourse)]
        public int? EndCourse { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CPFile)]
        public string CPFile { get; set; }
    }
}