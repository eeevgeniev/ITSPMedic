using Medic.App.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Medic.App.ViewComponents
{
    public class LanguageBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string language = MedicConstants.DefaultLanguage;

            if (ViewContext.HttpContext.Request.Cookies.TryGetValue(MedicConstants.LanguageCookieName, out string newValue))
            {
                newValue = newValue.ToLower();

                if (MedicConstants.AllowedLanguages.Contains(newValue))
                {
                    language = newValue;
                }
            }

            return View(nameof(LanguageBarViewComponent), language);
        }
    }
}
