using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.CPFiles
{
    public class CPFileSummaryViewModel
    {
        [Display(Name = MedicDataAnnotationLocalizerProvider.DateFrom)]
        public DateTime DateFrom { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PlanningsCount)]
        public int PlanningsCount { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.InsCount)]
        public int InsCount { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutsCount)]
        public int OutsCount { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProtocolDrugTherapiesCount)]
        public int ProtocolDrugTherapiesCount { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.PatientTransfersCount)]
        public int PatientTransfersCount { get; set; }
    }
}
