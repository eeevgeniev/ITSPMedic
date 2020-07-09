using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Patients
{
    public class PatientPreviewViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.BirthDate)]
        public DateTime BirthDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.FirstName)]
        public string FirstName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.SecondName)]
        public string SecondName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.LastName)]
        public string LastName { get; set; }
    }
}
