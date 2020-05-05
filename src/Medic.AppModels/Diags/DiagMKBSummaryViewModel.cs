using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Diags
{
    public class DiagMKBSummaryViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Count")]
        public int Count { get; set; }
    }
}
