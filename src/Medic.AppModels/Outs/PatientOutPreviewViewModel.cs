﻿using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Outs
{
    public class PatientOutPreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = MedicDataAnnotationLocalizerProvider.OutDate)]
        public DateTime OutDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MKBCode)]
        public string MKBCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MKBName)]
        public string MKBName { get; set; }
    }
}
