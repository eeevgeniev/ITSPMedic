using Medic.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Medic.App.Models.Users.Models
{
    public class ChangePassword
    {
        [DisplayName(MedicDataAnnotationLocalizerProvider.CurrentPassword)]
        [Required(ErrorMessage = MedicDataAnnotationLocalizerProvider.RequiredCurrentPassword)]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DisplayName(MedicDataAnnotationLocalizerProvider.NewPassword)]
        [Required(ErrorMessage = MedicDataAnnotationLocalizerProvider.RequiredNewPassword)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName(MedicDataAnnotationLocalizerProvider.ConfirmNewPassword)]
        [Required(ErrorMessage = MedicDataAnnotationLocalizerProvider.RequiredConfirmNewPassword)]
        [Compare(nameof(NewPassword), ErrorMessage = MedicDataAnnotationLocalizerProvider.CompareConfirmNewPassword)]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }
    }
}
