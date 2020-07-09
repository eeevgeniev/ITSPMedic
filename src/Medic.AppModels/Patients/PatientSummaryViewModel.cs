using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Patients
{
    public class PatientSummaryViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = MedicDataAnnotationLocalizerProvider.IdentityNumber)]
        public string IdentityNumber { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FirstName)]
        public string FirstName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SecondName)]
        public string SecondName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.LastName)]
        public string LastName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Sex)]
        public string Sex { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Address)]
        public string Address { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.BirthDate)]
        public DateTime BirthDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Notes)]
        public string Notes { get; set; }
    }
}
