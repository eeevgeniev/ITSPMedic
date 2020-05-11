using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Diagnoses
{
    public class DiagnosePreviewViewModel
    {
        [Display(Name = nameof(Name))]
        public string Name { get; set; }

        [Display(Name = nameof(Code))]
        public string Code { get; set; }
    }
}
