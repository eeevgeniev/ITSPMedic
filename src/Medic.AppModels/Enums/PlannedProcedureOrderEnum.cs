using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Enums
{
    public enum PlannedOrderEnum
    {
        [Display(Name = nameof(Default))]
        Default,
        [Display(Name = nameof(SendDate))]
        SendDate
    }
}
