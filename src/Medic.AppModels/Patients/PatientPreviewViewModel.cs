using System;

namespace Medic.AppModels.Patients
{
    public class PatientPreviewViewModel
    {
        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }
    }
}
