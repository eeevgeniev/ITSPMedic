using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Diags
{
    public class DiagPreviewViewModel
    {
        [Display(Name = nameof(Name))]
        public string Name { get; set; }

        [Display(Name = nameof(Code))]
        public string Code { get; set; }
    }
}
