using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Diags
{
    public class DiagMKBSummaryViewModel
    {
        [Display(Name = nameof(Name))]
        public string Name { get; set; }

        [Display(Name = nameof(Code))]
        public string Code { get; set; }

        [Display(Name = nameof(Count))]
        public int Count { get; set; }
    }
}
