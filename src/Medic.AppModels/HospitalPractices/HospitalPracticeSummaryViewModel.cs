using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.HospitalPractices
{
    public class HospitalPracticeSummaryViewModel
    {
        [Display(Name = nameof(DateFrom))]
        public DateTime DateFrom { get; set; }

        [Display(Name = nameof(InClinicProceduresCount))]
        public int InClinicProceduresCount { get; set; }

        [Display(Name = nameof(PathProceduresCount))]
        public int PathProceduresCount { get; set; }

        [Display(Name = nameof(DispObservationsCount))]
        public int DispObservationsCount { get; set; }

        [Display(Name = nameof(CommissionAprsCount))]
        public int CommissionAprsCount { get; set; }

        [Display(Name = nameof(ProtocolDrugTherapiesCount))]
        public int ProtocolDrugTherapiesCount { get; set; }

        [Display(Name = nameof(PatientTransfersCount))]
        public int PatientTransfersCount { get; set; }
    }
}
