using Medic.AppModels.Evaluations;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.APr38s
{
    public class APr38PreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(Height))]
        public int Height { get; set; }

        [Display(Name = nameof(Weight))]
        public int Weight { get; set; }

        [Display(Name = nameof(History))]
        public string History { get; set; }

        [Display(Name = nameof(FairCondition))]
        public string FairCondition { get; set; }

        [Display(Name = nameof(Therapy))]
        public string Therapy { get; set; }

        public EvaluationPreviewViewModel Decision { get; set; }
    }
}
