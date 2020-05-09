using System.ComponentModel.DataAnnotations;

namespace Medic.IdentityModels
{
    public class LoginInputModel
    {
        [Display(Name = "Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredUsername")]
        [MaxLength(100, ErrorMessage = "MaxLengthUsername")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "RequiredPassword")]
        [MaxLength(100, ErrorMessage = "MaxLengthPassword")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}