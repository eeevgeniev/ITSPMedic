using Medic.AppModels.HealthcarePractitioners;
using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.DoneProcedures
{
    public class DoneProcedureViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProcedureStartDate)]
        public DateTime? ProcedureStartDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProcedureStartDate)]
        public DateTime? ProcedureEndDate { get; set; }

        public HealthcarePractitionerSummaryViewModel Doctor { get; set; }
    }
}
