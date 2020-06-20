using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.InClinicProcedures
{
    public class PatientInClinicProcedurePreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PlanVisitDate)]
        public DateTime? PlanVisitDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MKBCode)]
        public string MKBCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MKBName)]
        public string MKBName { get; set; }
    }
}