using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Enums
{
    public enum PageLengthEnum
    {
        [Display (Name = nameof(SmallLength))]
        SmallLength = 10,
        [Display(Name = nameof(NormalLength))]
        NormalLength = 20,
        [Display(Name = nameof(LargeLength))]
        LargeLength = 40
    }
}