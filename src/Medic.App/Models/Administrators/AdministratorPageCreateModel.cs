using Medic.App.Models.Administrators.Models;
using Medic.App.Models.Bases;

namespace Medic.App.Models.Administrators
{
    public class AdministratorPageCreateModel : BasePageModel
    {
        public CreateUserInputModel User { get; set; }
    }
}
