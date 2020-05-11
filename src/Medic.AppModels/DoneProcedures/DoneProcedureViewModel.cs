using Medic.AppModels.HealthcarePractitioners;
using System;

namespace Medic.AppModels.DoneProcedures
{
    public class DoneProcedureViewModel
    {
        public int Id { get; set; }

        public DateTime? ProcedureStartDate { get; set; }

        public DateTime? ProcedureEndDate { get; set; }

        public HealthcarePractitionerSummaryViewModel Doctor { get; set; }
    }
}
