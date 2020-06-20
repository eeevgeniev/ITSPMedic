using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.HospitalPractices
{
    public class HospitalPracticeSummaryViewModel
    {
        [Display(Name = MedicDataAnnotationLocalizerProvider.DateFrom)]
        public DateTime DateFrom { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.InClinicProceduresCount)]
        public int InClinicProceduresCount { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PathProceduresCount)]
        public int PathProceduresCount { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DispObservationsCount)]
        public int DispObservationsCount { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CommissionAprsCount)]
        public int CommissionAprsCount { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProtocolDrugTherapiesCount)]
        public int ProtocolDrugTherapiesCount { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientTransfersCount)]
        public int PatientTransfersCount { get; set; }
    }
}
