using Medic.AppModels.Diagnoses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Outs
{
    public class OutPreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(UniqueIdentifier))]
        public string UniqueIdentifier { get; set; }

        [Display(Name = nameof(OutDate))]
        public DateTime OutDate { get; set; }

        [Display(Name = nameof(OutMainDiagnoseCode))]
        public string OutMainDiagnoseCode { get; set; }

        [Display(Name = nameof(OutMainDiagnoseName))]
        public string OutMainDiagnoseName { get; set; }

        public int PatientId { get; set; }

        [Display(Name = nameof(SendDiagnoses))]
        public List<DiagnosePreviewViewModel> SendDiagnoses { get; set; }

        [Display(Name = nameof(Diagnoses))]
        public List<DiagnosePreviewViewModel> Diagnoses { get; set; }

        [Display(Name = nameof(OutDiagnoses))]
        public List<DiagnosePreviewViewModel> OutDiagnoses { get; set; }

        [Display(Name = nameof(UsedDrugCodes))]
        public List<string> UsedDrugCodes { get; set; }
    }
}
