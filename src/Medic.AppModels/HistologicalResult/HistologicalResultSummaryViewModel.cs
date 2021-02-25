using Medic.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.HistologicalResult
{
    public class HistologicalResultSummaryViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = MedicDataAnnotationLocalizerProvider.Code)]
        public string Code { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Date)]
        public DateTime Date { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.Notes)]
        public string Note { get; set; }
    }
}