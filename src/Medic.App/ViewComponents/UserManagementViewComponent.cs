using Microsoft.AspNetCore.Mvc;

namespace Medic.App.ViewComponents
{
    public class UserManagementViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(nameof(UserManagementViewComponent), ViewContext.HttpContext.User.Identity.IsAuthenticated);
        }
    }
}
