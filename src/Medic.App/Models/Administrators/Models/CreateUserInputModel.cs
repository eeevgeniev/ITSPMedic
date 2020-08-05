using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Medic.App.Models.Administrators.Models
{
    public class CreateUserInputModel
    {
        [DisplayName(nameof(UserName))]
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [DisplayName(nameof(Email))]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName(nameof(Password))]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName(nameof(ConfirmPassword))]
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [DisplayName(nameof(IsAdministrator))]
        public bool IsAdministrator { get; set; } = false;
    }
}
