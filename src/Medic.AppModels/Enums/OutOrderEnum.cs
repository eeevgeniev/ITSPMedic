using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Enums
{
    public enum OutOrderEnum
    {
        [Display(Name = nameof(Default))]
        Default,
        [Display(Name = nameof(OutDate))]
        OutDate,
        [Display(Name = nameof(OutMainDiagnoseCode))]
        OutMainDiagnoseCode
    }
}