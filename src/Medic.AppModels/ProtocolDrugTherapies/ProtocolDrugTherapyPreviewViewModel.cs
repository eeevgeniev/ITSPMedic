using Medic.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.ProtocolDrugTherapies
{
    public class ProtocolDrugTherapyPreviewViewModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DecisionDate)]
        public DateTime DecisionDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.ProtocolDate)]
        public DateTime ProtocolDate { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DiagnoseCode)]
        public string DiagnoseCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DiagnoseName)]
        public string DiagnoseName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.DrugProtocolsATCNames)]
        public List<string> DrugProtocolsATCNames { get; set; } 
    }
}
