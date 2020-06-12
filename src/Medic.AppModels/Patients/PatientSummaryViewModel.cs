using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Patients
{
    public class PatientSummaryViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = nameof(IdentityNumber))]
        public string IdentityNumber { get; set; }

        [Display(Name = nameof(FirstName))]
        public string FirstName { get; set; }

        [Display(Name = nameof(SecondName))]
        public string SecondName { get; set; }

        [Display(Name = nameof(LastName))]
        public string LastName { get; set; }

        [Display(Name = nameof(Sex))]
        public string Sex { get; set; }

        [Display(Name = nameof(Address))]
        public string Address { get; set; }

        [Display(Name = nameof(BirthDate))]
        public DateTime BirthDate { get; set; }

        [Display(Name = nameof(Notes))]
        public string Notes { get; set; }
    }
}
