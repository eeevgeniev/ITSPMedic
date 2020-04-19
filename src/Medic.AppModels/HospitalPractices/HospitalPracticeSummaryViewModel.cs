using System;
using System.Collections.Generic;
using System.Text;

namespace Medic.AppModels.HospitalPractices
{
    public class HospitalPracticeSummaryViewModel
    {
        public DateTime DateFrom { get; set; }

        public int InClinicProceduresCount { get; set; }

        public int PathProceduresCount { get; set; }

        public int DispObservationsCount { get; set; }

        public int CommissionAprsCount { get; set; }

        public int ProtocolDrugTherapiesCount { get; set; }

        public int PatientTransfersCount { get; set; }
    }
}
