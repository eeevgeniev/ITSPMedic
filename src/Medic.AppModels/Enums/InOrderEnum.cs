using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Enums
{
    public enum InOrderEnum
    {
        [Display(Name = nameof(Default))]
        Default,
        [Display(Name = nameof(EntryDate))]
        EntryDate,
        [Display(Name = nameof(SendDiagnoseCode))]
        SendDiagnoseCode
    }
}
