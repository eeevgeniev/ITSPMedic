using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Diagnoses
{
    public class DiagnosePreviewViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Code")]
        public string Code { get; set; }
    }
}
