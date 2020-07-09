using Medic.Resources;
using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.UsedDrugs
{
    public class UsedDrugsSummaryStatistic
    {
        [Display(Name = MedicDataAnnotationLocalizerProvider.UsedDrugCode)]
        public string UsedDrugCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutDiagnoseName)]
        public string OutDiagnoseName { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.OutDiagnoseCode)]
        public string OutDiagnoseCode { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.TotalUses)]
        public int TotalUses { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.AverageQuantity)]
        public decimal AverageQuantity { get; set; }

        [Display(Name = MedicDataAnnotationLocalizerProvider.TotalCosts)]
        public decimal TotalCosts { get; set; }
    }
}
