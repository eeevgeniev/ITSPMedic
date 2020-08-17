using Medic.App.Controllers.Base;
using Medic.App.Models.Account;
using Medic.App.Models.Users.Models;
using Medic.IdentityModels;
using Medic.Logs.Contracts;
using Medic.Logs.Models;
using Medic.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using IR = Microsoft.AspNetCore.Identity;

namespace Medic.App.Controllers
{
    [Authorize]
    public class AccountController : MedicBaseController
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly GeneralLocalization GeneralLocalization;
        private readonly IMedicLoggerService MedicLoggerService;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            GeneralLocalization generalLocalization,
            IMedicLoggerService medicLoggerService)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            SignInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            GeneralLocalization = generalLocalization ?? throw new ArgumentNullException(nameof(generalLocalization));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl) => View(new AccountPageLoginModel()
        {
            Title = GeneralLocalization.Get(GeneralLocalization.Login),
            Description = GeneralLocalization.Get(GeneralLocalization.Login),
            Keywords = GeneralLocalization.Get(GeneralLocalization.Login),
            LoginInputModel = new LoginInputModel() { ReturnUrl = returnUrl }
        });

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(new AccountPageLoginModel()
                    {
                        Title = GeneralLocalization.Get(GeneralLocalization.Login),
                        Description = GeneralLocalization.Get(GeneralLocalization.Login),
                        Keywords = GeneralLocalization.Get(GeneralLocalization.Login),
                        LoginInputModel = model
                    });
                }

                IR.SignInResult result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, GeneralLocalization.InvalidTry);

                    return View(new AccountPageLoginModel()
                    {
                        Title = GeneralLocalization.Get(GeneralLocalization.Login),
                        Description = GeneralLocalization.Get(GeneralLocalization.Login),
                        Keywords = GeneralLocalization.Get(GeneralLocalization.Login),
                        LoginInputModel = model
                    });
                }

                if (!string.IsNullOrWhiteSpace(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return this.Redirect(model.ReturnUrl);
                }

                return RedirectToAction(nameof(HomeController.Index), GetControllerName(nameof(HomeController)));
            }
            catch (Exception ex)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log() 
                { 
                    Message = ex.Message, 
                    InnerExceptionMessage = ex?.InnerException?.Message ?? null, 
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                    Date = DateTime.Now
                });
                
                throw;
            }
        }

        public async Task<IActionResult> Logout()
        {
            try
            {
                await SignInManager.SignOutAsync();

                return RedirectToAction(nameof(HomeController.Index), GetControllerName(nameof(HomeController)));
            }
            catch (Exception ex)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log()
                {
                    Message = ex.Message,
                    InnerExceptionMessage = ex?.InnerException?.Message ?? null,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                    Date = DateTime.Now
                });

                throw;
            }
        }

        [HttpGet]
        public IActionResult Password() => View(new AccountPagePasswordModel
        {
            Title = GeneralLocalization.Get(GeneralLocalization.Password),
            Description = GeneralLocalization.Get(GeneralLocalization.Password),
            Keywords = GeneralLocalization.Get(GeneralLocalization.Password),
            ChangePassword = new ChangePassword()
        });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Password(ChangePassword model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(new AccountPagePasswordModel
                    {
                        Title = GeneralLocalization.Get(GeneralLocalization.Password),
                        Description = GeneralLocalization.Get(GeneralLocalization.Password),
                        Keywords = GeneralLocalization.Get(GeneralLocalization.Password),
                        ChangePassword = model
                    });
                }

                IdentityUser user = await UserManager.GetUserAsync(this.HttpContext.User);

                if (user == default)
                {
                    ModelState.AddModelError(string.Empty, GeneralLocalization.Get(GeneralLocalization.InvalidUser));

                    return View(new AccountPagePasswordModel
                    {
                        Title = GeneralLocalization.Get(GeneralLocalization.Password),
                        Description = GeneralLocalization.Get(GeneralLocalization.Password),
                        Keywords = GeneralLocalization.Get(GeneralLocalization.Password),
                        ChangePassword = model
                    });
                }

                IdentityResult passwordResult = await UserManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (!passwordResult.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, GeneralLocalization.Get(GeneralLocalization.PasswordUpdateError));

                    return View(new AccountPagePasswordModel
                    {
                        Title = GeneralLocalization.Get(GeneralLocalization.Password),
                        Description = GeneralLocalization.Get(GeneralLocalization.Password),
                        Keywords = GeneralLocalization.Get(GeneralLocalization.Password),
                        ChangePassword = model
                    });
                }

                return RedirectToAction(nameof(HomeController.Index), AccountController.GetName(nameof(AccountController)));
            }
            catch (Exception ex)
            {
                Task<int> _ = MedicLoggerService.SaveAsync(new Log()
                {
                    Message = ex.Message,
                    InnerExceptionMessage = ex?.InnerException?.Message ?? null,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace,
                    Date = DateTime.Now
                });

                throw;
            }
        }

        [AllowAnonymous]
        public IActionResult AccessDenied() => View();
    }
}