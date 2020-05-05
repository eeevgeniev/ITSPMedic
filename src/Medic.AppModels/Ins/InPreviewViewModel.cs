using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Ins
{
    public class InPreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(EntryDate))]
        public DateTime EntryDate { get; set; }

        [Display(Name = nameof(SendDiagnoseCode))]
        public string SendDiagnoseCode { get; set; }

        [Display(Name = nameof(SendDiagnoseName))]
        public string SendDiagnoseName { get; set; }

        public int PatientId { get; set; }

        [Display(Name = nameof(CodeDiagnoses))]
        public List<string> CodeDiagnoses { get; set; }
    }
}