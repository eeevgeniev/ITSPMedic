using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.CeasedClinicals
{
    public class CeasedClinicalViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Code)]
        public string Code { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IZMedicalWard)]
        public int IZMedicalWard { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.IZYearMedicalWard)]
        public int IZYearMedicalWard { get; set; }
    }
}
