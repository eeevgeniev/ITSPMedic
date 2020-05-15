using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.ProtocolDrugTherapies
{
    public class PatientProtocolDrugTherapyPreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = nameof(ProtocolDate))]
        public DateTime ProtocolDate { get; set; }

        [Display(Name = nameof(MKBCode))]
        public string MKBCode { get; set; }

        [Display(Name = nameof(MKBName))]
        public string MKBName { get; set; }
    }
}
