using Medic.AppModels.Diagnoses;
using Medic.AppModels.Epicrisises;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.HistologicalResult;
using Medic.AppModels.Patients;
using Medic.AppModels.Procedures;
using Medic.AppModels.UsedDrugs;
using System;
using System.Collections.Generic;

namespace Medic.AppModels.Outs
{
    public class OutViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        public string PatientBranch { get; set; } // map in out

        public string PatientHRegion { get; set; } // map in out

        public int InType { get; set; }

        public HealthcarePractitionerSummaryViewModel Sender { get; set; }

        public DateTime SendDate { get; set; }

        public DiagnosePreviewViewModel SendDiagnose { get; set; }

        public int SendUrgency { get; set; }

        public double SendClinicalPath { get; set; }

        public string UniqueIdentifier { get; set; }

        public DateTime ExaminationDate { get; set; }

        public List<DiagnosePreviewViewModel> Diagnoses { get; set; }

        public int Urgency { get; set; }

        public double ClinicalPath { get; set; }

        public int NZOKPay { get; set; }

        public decimal InMedicalWard { get; set; }

        public DateTime EntryDate { get; set; }

        public int Severity { get; set; }

        public int Delay { get; set; }

        public int Payer { get; set; }

        public int AgeInDays { get; set; }

        public int WeightInGrams { get; set; }

        public int BirthWeight { get; set; }

        public int MotherIZYear { get; set; }

        public int MotherIZNo { get; set; }

        public int IZYear { get; set; }

        public int IZNo { get; set; }

        public decimal OutMedicalWard { get; set; }

        public string OutUniqueIdentifier { get; set; }

        public DateTime OutDate { get; set; }

        public int OutType { get; set; }

        public DiagnosePreviewViewModel Dead { get; set; }

        public string BirthPractice { get; set; }

        public int BirthNumber { get; set; }

        public int BirthGestWeek { get; set; }

        public double OutClinicalPath { get; set; }

        public string OutAPr { get; set; }

        public HistologicalResultSummaryViewModel HistologicalResult { get; set; }

        public EpicrisisSummaryViewModel Epicrisis { get; set; }

        public DiagnosePreviewViewModel OutMainDiagnose { get; set; }

        public List<DiagnosePreviewViewModel> OutDiagnoses { get; set; }

        public UsedDrugSummaryViewModel UsedDrug { get; set; } // BatchNumber, QuantityPack

        public List<ProcedureSummaryViewModel> Procedures { get; set; } // ImplantReferenceNumber, ImplantManufacturer, ImplantCode

        public int BedDays { get; set; }

        public DateTime? HLDateFrom { get; set; }

        public string HLNumber { get; set; }

        public int HLTotalDays { get; set; }

        public int StateAtDischarge { get; set; }

        public int Laparoscopic { get; set; }

        public int EndCourse { get; set; }

        public string CPFile { get; set; } // map in out
    }
}