using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Patients
{
    public class PatientPreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(BirthDate))]
        public DateTime BirthDate { get; set; }

        [Display(Name = nameof(FirstName))]
        public string FirstName { get; set; }

        [Display(Name = nameof(SecondName))]
        public string SecondName { get; set; }

        [Display(Name = nameof(LastName))]
        public string LastName { get; set; }
    }
}
