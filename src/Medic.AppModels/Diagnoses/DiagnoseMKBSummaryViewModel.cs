using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Diagnoses
{
    public class DiagnoseMKBSummaryViewModel
    {
        [Display(Name = MedicDataAnnotationLocalizerProvider.Name)]
        public string Name { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Code)]
        public string Code { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Count)]
        public int Count { get; set; }
    }
}
