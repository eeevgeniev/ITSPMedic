using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Practices
{
    public class PracticePreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Branch)]
        public int Branch { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Number)]
        public string Number { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Code)]
        public string Code { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Name)]
        public string Name { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.HealthRegion)]
        public string HealthRegion { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Address)]
        public string Address { get; set; }
    }
}
