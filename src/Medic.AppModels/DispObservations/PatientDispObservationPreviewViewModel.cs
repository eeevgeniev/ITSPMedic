using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.DispObservations
{
    public class PatientDispObservationPreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = nameof(DispDate))]
        public DateTime DispDate { get; set; }

        [Display(Name = nameof(MKBCode))]
        public string MKBCode { get; set; }

        [Display(Name = nameof(MKBName))]
        public string MKBName { get; set; }
    }
}
