using Medic.AppModels.Evaluations;
using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.APr38s
{
    public class APr38PreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Height)]
        public int Height { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Weight)]
        public int Weight { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.History)]
        public string History { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FairCondition)]
        public string FairCondition { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Therapy)]
        public string Therapy { get; set; }

        public EvaluationPreviewViewModel Decision { get; set; }
    }
}
