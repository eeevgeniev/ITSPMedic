using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Medic.AppModels.Outs
{
    public class PatientOutPreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = nameof(OutDate))]
        public DateTime OutDate { get; set; }

        [Display(Name = nameof(MKBCode))]
        public string MKBCode { get; set; }

        [Display(Name = nameof(MKBName))]
        public string MKBName { get; set; }
    }
}
