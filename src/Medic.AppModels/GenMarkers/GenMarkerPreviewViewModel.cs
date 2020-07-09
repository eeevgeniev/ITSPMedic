using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.GenMarkers
{
    public class GenMarkerPreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Name)]
        public string Name { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Sign)]
        public int Sign { get; set; }
    }
}
