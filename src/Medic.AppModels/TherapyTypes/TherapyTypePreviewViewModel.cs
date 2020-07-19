using Medic.Resources;
using System.ComponentModel.DataAnnotations;

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
