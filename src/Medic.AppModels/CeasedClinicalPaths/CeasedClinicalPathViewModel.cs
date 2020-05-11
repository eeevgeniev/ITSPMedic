using System.ComponentModel.DataAnnotations;

namespace Medic.AppModels.CeasedClinicalPaths
{
    public class CeasedClinicalPathViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(Code))]
        public string Code { get; set; }

        [Display(Name = nameof(IZMedicalWard))]
        public int IZMedicalWard { get; set; }

        [Display(Name = nameof(IZMedicalWard))]
        public int IZYearMedicalWard { get; set; }
    }
}
