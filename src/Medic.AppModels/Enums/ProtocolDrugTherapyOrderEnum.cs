using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Enums
{
    public enum ProtocolDrugTherapyOrderEnum
    {
        [Display(Name = nameof(Default))]
        Default,
        [Display(Name = nameof(DecisionDate))]
        DecisionDate,
        [Display(Name = nameof(DiagnoseCode))]
        DiagnoseCode,
        [Display(Name = nameof(ProtocolDate))]
        ProtocolDate
    }
}
