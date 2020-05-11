using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.HealthRegions
{
    public class HealthRegionOption
    {
        public int? Id { get; set; }

        [Display(Name = nameof(Name))]
        public string Name { get; set; }
    }
}