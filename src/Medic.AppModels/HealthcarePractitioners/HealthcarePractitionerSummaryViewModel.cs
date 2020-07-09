using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.HealthcarePractitioners
{
    public class HealthcarePractitionerSummaryViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = MedicDataAnnotationLocalizerProvider.UniqueIdentifier)]
        public string UniqueIdentifier { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DeputyUniqueIdentifier)]
        public string DeputyUniqueIdentifier { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Speciality)]
        public string Speciality { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Name)]
        public string Name { get; set; }
    }
}
