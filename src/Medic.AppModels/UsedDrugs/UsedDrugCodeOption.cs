using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.UsedDrugs
{
    public class UsedDrugCodeOption
    {
        [Display(Name = MedicDataAnnotationLocalizerProvider.Key)]
        public string Key { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Code)]
        public string Code { get; set; }
    }
}
