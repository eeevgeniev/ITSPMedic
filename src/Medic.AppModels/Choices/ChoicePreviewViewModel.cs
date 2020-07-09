using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Choices
{
    public class ChoicePreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Number)]
        public int Number { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Checked)]
        public int Checked { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Text)]
        public string Text { get; set; }
    }
}