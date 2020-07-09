using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Diagnoses
{
    public class DiagnosePreviewViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = MedicDataAnnotationLocalizerProvider.Name)]
        public string Name { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Code)]
        public string Code { get; set; }

        public override string ToString()
        {
            string name = string.IsNullOrEmpty(Name) ? string.Empty : $" - {Name}";

            return $"{Code}{name}";
        }
    }
}
