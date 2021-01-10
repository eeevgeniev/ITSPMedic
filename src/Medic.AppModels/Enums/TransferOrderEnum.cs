using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Enums
{
    public enum TransferOrderEnum
    {
        [Display(Name = nameof(Default))]
        Default,
        [Display(Name = nameof(FirstMainDiagCode))]
        FirstMainDiagCode,
        [Display(Name = nameof(SecondMainDiagCode))]
        SecondMainDiagCode,
        [Display(Name = nameof(TransferDate))]
        TransferDate
    }
}
