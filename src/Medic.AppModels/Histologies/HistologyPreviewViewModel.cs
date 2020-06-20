using Medic.AppModels.APr05s;
using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Histologies
{
    public class HistologyPreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.NameHS)]
        public string NameHS { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.CodeHS)]
        public string CodeHS { get; set; }

        public APr05PreviewViewModel APr05 { get; set; }
    }
}
