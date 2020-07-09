using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.DispObservations
{
    public class DispObservationPreviewViewModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DispDate)]
        public DateTime DispDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FirstMainDiagCode)]
        public string FirstMainDiagCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FirstMainDiagName)]
        public string FirstMainDiagName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SecondMainDiagCode)]
        public string SecondMainDiagCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SecondMainDiagName)]
        public string SecondMainDiagName { get; set; }
    }
}
