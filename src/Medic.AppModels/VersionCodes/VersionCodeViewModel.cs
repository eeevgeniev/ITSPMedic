using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.VersionCodes
{
    public class VersionCodeViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.BatchNumber)]
        public string BatchNumber { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.QuantityPack)]
        public decimal QuantityPack { get; set; }
    }
}
