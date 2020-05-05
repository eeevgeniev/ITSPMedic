using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.UsedDrugs
{
    public class UsedDrugCodeOption
    {
        [Display(Name = nameof(Key))]
        public string Key { get; set; }

        [Display(Name = nameof(Code))]
        public string Code { get; set; }
    }
}
