using System;

namespace Medic.AppModels.CPFiles
{
    public class CPFileSummaryViewModel
    {
        public DateTime DateFrom { get; set; }

        public int PlannedProceduresCount { get; set; }

        public int InsCount { get; set; }

        public int OutsCount { get; set; }

        public int ProtocolDrugTherapiesCount { get; set; }

        public int PatientTransfersCount { get; set; }
    }
}
