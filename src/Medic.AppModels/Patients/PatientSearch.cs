using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Patients
{
    /// <summary>
    /// Class for managing patient search
    /// </summary>
    public class PatientSearch
    {
        [Display(Name = nameof(IdentityNumber))]
        public string IdentityNumber { get; set; }

        [Display(Name = nameof(Age))]
        public int? Age { get; set; }

        [Display(Name = nameof(OlderThan))]
        public int? OlderThan { get; set; }

        [Display(Name = nameof(YoungerThan))]
        public int? YoungerThan { get; set; }

        [Display(Name = nameof(Sex))]
        public int? Sex { get; set; }
    }
}