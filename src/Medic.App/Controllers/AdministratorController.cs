using Medic.App.Controllers.Base;
using Medic.App.Infrastructure;
using Medic.App.Models.Administrators;
using Medic.App.Models.Administrators.Models;
using Medic.Identity;
using Medic.Logs.Contracts;
using Medic.Logs.Models;
using Medic.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.App.Controllers
{
    [Authorize(Roles = MedicIdentityConstants.Administrator)]
    public class AdministratorController : PageBasedController
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly IMedicLoggerService MedicLoggerService;
        private readonly MedicDataLocalization MedicDataLocalization;
        private readonly string DefaultAdministratorName;

        private const int Length = 20;

        public AdministratorController(UserManager<IdentityUser> userManager,
            IMedicLoggerService medicLoggerService,
            MedicDataLocalization medicDataLocalization,
            IConfiguration configuration)
        {
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            MedicLoggerService = medicLoggerService ?? throw new ArgumentNullException(nameof(medicLoggerService));
            MedicDataLocalization = medicDataLocalization ?? throw new ArgumentNullException(nameof(medicDataLocalization));
            DefaultAdministratorName = configuration[MedicConstants.AdministratorName];
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            try
            {
                AdministratorPageIndexModel administratorPageIndexModel = await Task.Run(() =>
                {
                    int totalCount = UserManager.Users.Count();
                    int startIndex = base.GetStartIndex(Length, page);

                    return new AdministratorPageIndexModel()
                    {
                        Title = MedicDataLocalization.Administrator,
                        Error = default,
                        Description = default,
                        Keywords = default,
                        CurrentPage = page,
                        TotalPages = base.TotalPages(Length, totalCount),
                        TotalResults = totalCount,
                        Users = this.GetUsers(startIndex, Length)
                    };
                });

                return View(administratorPageIndexModel);
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
        public IActionResult Create() => View(new AdministratorPageCreateModel()
        {
            Title = MedicDataLocalization.Get(MedicDataLocalization.CreateUser),
            Error = default,
            Description = default,
            Keywords = default,
            User = new CreateUserInputModel()
        });

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserInputModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(new AdministratorPageCreateModel()
                    {
                        Title = MedicDataLocalization.Get(MedicDataLocalization.CreateUser),
                        Error = default,
                        Description = default,
                        Keywords = default,
                        User = model
                    });
                }

                IdentityUser user = new IdentityUser()
                {
                    UserName = model.Username,
                    Email = model.Email
                };

                IdentityResult identityResult = await UserManager.CreateAsync(user, model.Password);

                string error = default;

                if (!identityResult.Succeeded)
                {
                    error = string.Join(MedicConstants.IdentityErrorSeparator, identityResult.Errors.Select(ie => ie.Description));

                    ModelState.AddModelError(MedicDataLocalization.UserCreation, error);

                    return View(new AdministratorPageCreateModel()
                    {
                        Title = MedicDataLocalization.Get(MedicDataLocalization.CreateUser),
                        Error = error,
                        Description = default,
                        Keywords = default,
                        User = model
                    });
                }

                if (model.IsAdministrator)
                {
                    IdentityResult roleResult = await UserManager.AddToRoleAsync(user, MedicIdentityConstants.Administrator);

                    if (roleResult.Succeeded)
                    {
                        error = string.Join(MedicConstants.IdentityErrorSeparator, roleResult.Errors.Select(ie => ie.Description));

                        ModelState.AddModelError(MedicDataLocalization.RoleCreation, error);

                        return View(new AdministratorPageCreateModel()
                        {
                            Title = MedicDataLocalization.Get(MedicDataLocalization.CreateUser),
                            Error = error,
                            Description = default,
                            Keywords = default,
                            User = model
                        });
                    }
                }

                return RedirectToAction(nameof(AdministratorController.Index), GetName(nameof(AdministratorController)));
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string username, int page = 1)
        {
            try
            {
                if (string.Equals(username, DefaultAdministratorName) || string.Equals(username, HttpContext.User.Identity.Name))
                {
                    return RedirectToAction(nameof(AdministratorController.Index), GetName(nameof(AdministratorController)), new { page });
                }

                IdentityUser user = UserManager.Users.FirstOrDefault(u => EF.Functions.Like(u.UserName, username));

                if (user != default)
                {
                    IdentityResult deleteResult = await UserManager.DeleteAsync(user);

                    if (!deleteResult.Succeeded)
                    {
                        int totalCount = UserManager.Users.Count();
                        int startIndex = base.GetStartIndex(Length, page);

                        AdministratorPageIndexModel pageModel = new AdministratorPageIndexModel()
                        {
                            Title = MedicDataLocalization.Administrator,
                            Error = string.Join(MedicConstants.IdentityErrorSeparator, deleteResult.Errors.Select(dr => dr.Description)),
                            Description = default,
                            Keywords = default,
                            CurrentPage = page,
                            TotalPages = base.TotalPages(Length, totalCount),
                            TotalResults = totalCount,
                            Users = GetUsers(startIndex, Length)
                        };

                        return View("~/Views/Administration/Index.cshtml", pageModel);
                    }
                }

                return RedirectToAction(nameof(AdministratorController.Index), GetName(nameof(AdministratorController)), new { page });
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

        private List<UserViewModel> GetUsers(int startIndex, int length) =>
            UserManager.Users
                .Where(u => !EF.Functions.Like(u.UserName, DefaultAdministratorName) && !EF.Functions.Like(u.UserName, HttpContext.User.Identity.Name))
                .Select(u => new UserViewModel() { Id = u.Id, Username = u.UserName, Email = u.Email })
                .Skip(startIndex)
                .Take(length)
                .ToList();
    }
}
