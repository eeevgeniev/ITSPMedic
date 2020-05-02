using Medic.AppModels.Diagnoses;
using Medic.AppModels.HealthcarePractitioners;
using Medic.AppModels.Patients;
using System;
using System.Collections.Generic;

namespace Medic.AppModels.Ins
{
    public class InViewModel
    {
        public int Id { get; set; }

        public PatientSummaryViewModel Patient { get; set; }

        public string PatientBranch { get; set; }

        public string PatientHRegion { get; set; }

        public int InType { get; set; }

        public HealthcarePractitionerSummaryViewModel Sender { get; set; }

        public DateTime SendDate { get; set; }

        public DiagnosePreviewViewModel SendDiagnose { get; set; }

        public int SendUrgency { get; set; }

        public int? SendApr { get; set; }

        public string SendClinicalPath { get; set; }

        public string UniqueIdentifier { get; set; }

        public DateTime ExaminationDate { get; set; }

        public int PlannedNumber { get; set; }

        public List<DiagnosePreviewViewModel> Diagnoses { get; set; }

        public int Urgency { get; set; }

        public int? InApr { get; set; }

        public string ClinicalPath { get; set; }

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

        public string CPFile { get; set; }
    }
}
