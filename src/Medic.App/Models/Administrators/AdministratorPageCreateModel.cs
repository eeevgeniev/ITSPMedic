using Medic.App.Models.Bases;
using Medic.IdentityModels;

namespace Medic.App.Models.Administrators
{
    public class AdministratorPageCreateModel : BasePageModel
    {
        public CreateUserInputModel User { get; set; }
    }
}
