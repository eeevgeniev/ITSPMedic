using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.PlannedProcedures
{
    public class PatientPlannedProcedurePreviewViewModel
    {
        [Display(Name = nameof(ExaminationDate))]
        public DateTime ExaminationDate { get; set; }

        [Display(Name = nameof(MKBCode))]
        public string MKBCode { get; set; }

        [Display(Name = nameof(MKBName))]
        public string MKBName { get; set; }
    }
}
