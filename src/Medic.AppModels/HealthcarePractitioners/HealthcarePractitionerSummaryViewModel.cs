using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.HealthcarePractitioners
{
    public class HealthcarePractitionerSummaryViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = nameof(UniqueIdentifier))]
        public string UniqueIdentifier { get; set; }

        [Display(Name = nameof(DeputyUniqueIdentifier))]
        public string DeputyUniqueIdentifier { get; set; }

        [Display(Name = nameof(Speciality))]
        public string Speciality { get; set; }

        [Display(Name = nameof(Name))]
        public string Name { get; set; }
    }
}
