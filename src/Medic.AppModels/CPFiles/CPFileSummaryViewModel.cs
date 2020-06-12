using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.CPFiles
{
    public class CPFileSummaryViewModel
    {
        [Display(Name = "DateFrom")]
        public DateTime DateFrom { get; set; }

        [Display(Name = "PlanningsCount")]
        public int PlanningsCount { get; set; }

        [Display(Name = "InsCount")]
        public int InsCount { get; set; }

        [Display(Name = "OutsCount")]
        public int OutsCount { get; set; }

        [Display(Name = "ProtocolDrugTherapiesCount")]
        public int ProtocolDrugTherapiesCount { get; set; }

        [Display(Name = "PatientTransfersCount")]
        public int PatientTransfersCount { get; set; }
    }
}
