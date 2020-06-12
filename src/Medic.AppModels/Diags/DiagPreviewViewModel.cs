using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Diags
{
    public class DiagPreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = nameof(Name))]
        public string Name { get; set; }

        [Display(Name = nameof(Code))]
        public string Code { get; set; }

        public override string ToString()
        {
            string name = string.IsNullOrEmpty(Name) ? string.Empty : $" - {Name}";

            return $"{Code}{name}";
        }
    }
}
