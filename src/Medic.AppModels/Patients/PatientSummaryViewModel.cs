using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.AppModels.Patients
{
    public class PatientSummaryViewModel
    {
        public string IdentityNumber { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        public string Notes { get; set; }
    }
}
