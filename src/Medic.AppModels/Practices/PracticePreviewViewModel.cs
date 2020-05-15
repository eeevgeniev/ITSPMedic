using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Practices
{
    public class PracticePreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(Branch))]
        public int Branch { get; set; }

        [Display(Name = nameof(Number))]
        public string Number { get; set; }

        [Display(Name = nameof(Code))]
        public string Code { get; set; }

        [Display(Name = nameof(Name))]
        public string Name { get; set; }

        [Display(Name = nameof(HealthRegion))]
        public string HealthRegion { get; set; }

        [Display(Name = nameof(Address))]
        public string Address { get; set; }
    }
}
