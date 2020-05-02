using System;

namespace Medic.AppModels.HistologicalResult
{
    public class HistologicalResultSummaryViewModel
    {
        public int Id { get; set; }
        
        public decimal Code { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }
    }
}
