using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.MDIs
{
    public class MDISummaryViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(MDIName))]
        public string MDIName { get; set; }

        [Display(Name = nameof(MDICode))]
        public decimal MDICode { get; set; }
    }
}