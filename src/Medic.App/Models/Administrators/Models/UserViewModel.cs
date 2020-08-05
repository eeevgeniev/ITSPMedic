using System.ComponentModel;

namespace Medic.App.Models.Administrators.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }

        [DisplayName(nameof(Username))]
        public string Username { get; set; }

        [DisplayName(nameof(Email))]
        public string Email { get; set; }
    }
}
