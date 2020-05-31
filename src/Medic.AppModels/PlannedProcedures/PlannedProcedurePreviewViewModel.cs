using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Medic.AppModels.PlannedProcedures
{
    public class PlannedProcedurePreviewViewModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        [Display(Name = nameof(SendDate))]
        public DateTime SendDate { get; set; }

        [Display(Name = nameof(SendDiagnoseCode))]
        public string SendDiagnoseCode { get; set; }

        [Display(Name = nameof(SendDiagnoseName))]
        public string SendDiagnoseName { get; set; }

        [Display(Name = nameof(DiagnoseCode))]
        public string DiagnoseCode { get; set; }

        [Display(Name = nameof(DiagnoseName))]
        public string DiagnoseName { get; set; }
    }
}
