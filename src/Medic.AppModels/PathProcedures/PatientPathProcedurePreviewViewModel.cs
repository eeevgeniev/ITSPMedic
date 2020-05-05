using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.PathProcedures
{
    public class PatientPathProcedurePreviewViewModel
    {
        [Display(Name = nameof(DateSend))]
        public DateTime DateSend { get; set; }

        [Display(Name = nameof(MKBCode))]
        public string MKBCode { get; set; }

        [Display(Name = nameof(MKBName))]
        public string MKBName { get; set; }
    }
}