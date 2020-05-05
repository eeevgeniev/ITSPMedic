using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Outs
{
    public class OutPreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(OutDate))]
        public DateTime OutDate { get; set; }

        [Display(Name = nameof(OutMainDiagnoseCode))]
        public string OutMainDiagnoseCode { get; set; }

        [Display(Name = nameof(OutMainDiagnoseName))]
        public string OutMainDiagnoseName { get; set; }

        public int PatientId { get; set; }

        [Display(Name = nameof(OutCodeDiagnoses))]
        public List<string> OutCodeDiagnoses { get; set; }

        [Display(Name = nameof(SendDiagnoseCode))]
        public string SendDiagnoseCode { get; set; }

        [Display(Name = nameof(Diagnoses))]
        public List<string> Diagnoses { get; set; }

        [Display(Name = nameof(UsedDrugCode))]
        public string UsedDrugCode { get; set; }
    }
}
