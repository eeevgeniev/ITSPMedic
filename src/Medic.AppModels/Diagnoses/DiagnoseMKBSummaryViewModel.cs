using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Diagnoses
{
    public class DiagnoseMKBSummaryViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }

        [Display(Name = "Count")]
        public int Count { get; set; }
    }
}
