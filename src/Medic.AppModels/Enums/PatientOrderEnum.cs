using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Enums
{
    public enum PatientOrderEnum
    {
        [Display(Name = nameof(Default))]
        Default,
        [Display(Name = nameof(BirthDate))]
        BirthDate,
        [Display(Name = nameof(IdentityNumber))]
        IdentityNumber
    }
}
