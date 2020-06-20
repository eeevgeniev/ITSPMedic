using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.HealthRegions
{
    public class HealthRegionOption
    {
        public int? Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Name)]
        public string Name { get; set; }
    }
}