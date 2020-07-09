using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.DispObservations
{
    public class PatientDispObservationPreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = MedicDataAnnotationLocalizerProvider.DispDate)]
        public DateTime DispDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MKBCode)]
        public string MKBCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MKBName)]
        public string MKBName { get; set; }
    }
}
