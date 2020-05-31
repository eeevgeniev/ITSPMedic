using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.ProtocolDrugTherapies
{
    public class ProtocolDrugTherapyPreviewViewModel
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        [Display(Name = nameof(DecisionDate))]
        public DateTime DecisionDate { get; set; }

        [Display(Name = nameof(ProtocolDate))]
        public DateTime ProtocolDate { get; set; }

        [Display(Name = nameof(DiagnoseCode))]
        public string DiagnoseCode { get; set; }

        [Display(Name = nameof(DiagnoseName))]
        public string DiagnoseName { get; set; }

        [Display(Name = nameof(DrugProtocolsATCNames))]
        public List<string> DrugProtocolsATCNames { get; set; } 
    }
}
