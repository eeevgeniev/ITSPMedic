using Medic.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Medic.App.Models.Administrators.Models
{
    public class CreateUserInputModel
    {
        [DisplayName(MedicDataAnnotationLocalizerProvider.UserName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = MedicDataAnnotationLocalizerProvider.RequiredUserName)]
        public string UserName { get; set; }

        [DisplayName(MedicDataAnnotationLocalizerProvider.Email)]
        [Required(AllowEmptyStrings = false, ErrorMessage = MedicDataAnnotationLocalizerProvider.RequiredEmail)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName(MedicDataAnnotationLocalizerProvider.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = MedicDataAnnotationLocalizerProvider.RequiredPassword)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName(MedicDataAnnotationLocalizerProvider.ConfirmPassword)]
        [Required(AllowEmptyStrings = false, ErrorMessage = MedicDataAnnotationLocalizerProvider.RequiredConfirmPassword)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = MedicDataAnnotationLocalizerProvider.ComparePasswords)]
        public string ConfirmPassword { get; set; }

        [DisplayName(MedicDataAnnotationLocalizerProvider.IsAdministrator)]
        public bool IsAdministrator { get; set; } = false;
    }
}
