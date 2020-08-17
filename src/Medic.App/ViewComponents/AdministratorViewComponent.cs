using Medic.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Medic.App.ViewComponents
{
    public class AdministratorViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(nameof(AdministratorViewComponent), ViewContext.HttpContext.User.IsInRole(MedicIdentityConstants.Administrator));
        }
    }
}
