using System;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.HistologicalResult
{
    public class HistologicalResultSummaryViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = nameof(Code))]
        public decimal Code { get; set; }

        [Display(Name = nameof(Date))]
        public DateTime Date { get; set; }

        [Display(Name = nameof(Note))]
        public string Note { get; set; }
    }
}