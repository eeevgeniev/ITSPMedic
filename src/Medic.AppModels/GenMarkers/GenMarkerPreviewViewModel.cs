using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.GenMarkers
{
    public class GenMarkerPreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(Name))]
        public string Name { get; set; }

        [Display(Name = nameof(Sign))]
        public int Sign { get; set; }
    }
}
