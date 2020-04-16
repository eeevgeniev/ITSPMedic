using Microsoft.AspNetCore.Mvc;

namespace Medic.App.Controllers.Base
{
    public abstract class MedicBaseController : Controller
    {
        public string GetControllerName(string name)
        {
            return name.Replace("Controller", string.Empty);
        }
    }
}
