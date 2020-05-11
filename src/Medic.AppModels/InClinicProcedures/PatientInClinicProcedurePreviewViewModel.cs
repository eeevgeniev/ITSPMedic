using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.InClinicProcedures
{
    public class PatientInClinicProcedurePreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(PlanVisitDate))]
        public DateTime? PlanVisitDate { get; set; }

        [Display(Name = nameof(MKBCode))]
        public string MKBCode { get; set; }

        [Display(Name = nameof(MKBName))]
        public string MKBName { get; set; }
    }
}