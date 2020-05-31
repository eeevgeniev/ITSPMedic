using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Enums
{
    public enum DispObservationOrderEnum
    {
        [Display(Name = nameof(Default))]
        Default,
        [Display(Name = nameof(DispDate))]
        DispDate,
        [Display(Name = nameof(FirstMainDiagCode))]
        FirstMainDiagCode,
        [Display(Name = nameof(SecondMainDiagCode))]
        SecondMainDiagCode
    }
}
