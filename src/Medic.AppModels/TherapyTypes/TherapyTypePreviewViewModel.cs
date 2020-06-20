using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Medic.AppModels.TherapyTypes
{
    public class TherapyTypePreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Code)]
        public int Code { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Name)]
        public string Name { get; set; }
    }
}
