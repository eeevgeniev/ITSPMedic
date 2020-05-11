using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.UsedDrugs
{
    public class UsedDrugsSummaryStatistic
    {
        [Display(Name = nameof(UsedDrugCode))]
        public string UsedDrugCode { get; set; }

        [Display(Name = nameof(SendDiagnoseName))]
        public string SendDiagnoseName { get; set; }

        [Display(Name = nameof(SendDignoseCode))]
        public string SendDignoseCode { get; set; }

        [Display(Name = nameof(OutDiagnoseName))]
        public string OutDiagnoseName { get; set; }

        [Display(Name = nameof(OutDiagnoseCode))]
        public string OutDiagnoseCode { get; set; }

        [Display(Name = nameof(TotalUses))]
        public int TotalUses { get; set; }

        [Display(Name = nameof(AverageQuantity))]
        public decimal AverageQuantity { get; set; }

        [Display(Name = nameof(TotalCosts))]
        public decimal TotalCosts { get; set; }
    }
}
