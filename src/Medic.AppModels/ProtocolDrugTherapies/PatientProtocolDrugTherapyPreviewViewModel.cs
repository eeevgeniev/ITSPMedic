using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.ProtocolDrugTherapies
{
    public class PatientProtocolDrugTherapyPreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = MedicDataAnnotationLocalizerProvider.ProtocolDate)]
        public DateTime ProtocolDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MKBCode)]
        public string MKBCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MKBName)]
        public string MKBName { get; set; }
    }
}
