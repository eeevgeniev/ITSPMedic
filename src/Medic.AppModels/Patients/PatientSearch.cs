using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.AppModels.Patients
{
    /// <summary>
    /// Class for managing patient search
    /// </summary>
    public class PatientSearch
    {
        public string IdentityNumber { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; } = null;
    }
}