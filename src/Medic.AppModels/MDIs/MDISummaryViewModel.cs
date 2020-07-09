using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.MDIs
{
    public class MDISummaryViewModel
    {
        public int Id { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MDIName)]
        public string MDIName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.MDICode)]
        public decimal MDICode { get; set; }
    }
}