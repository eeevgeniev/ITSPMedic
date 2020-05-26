using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.Enums
{
    public enum OrderDirectionEnum
    {
        [Display(Name = nameof(Asc))]
        Asc,
        [Display(Name = nameof(Desc))]
        Desc
    }
}
