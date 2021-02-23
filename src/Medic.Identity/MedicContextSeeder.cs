using Medic.Identity.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medic.Identity
{
    public class MedicContextSeeder : IMedicContextSeeder
    {
        private readonly MedicIdentityContext MedicIdentityContext;
        private readonly UserManager<IdentityUser> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;

        public MedicContextSeeder(
            MedicIdentityContext medicIdentityContext,
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            MedicIdentityContext = medicIdentityContext ?? throw new ArgumentNullException(nameof(medicIdentityContext));
            UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            RoleManager = roleManager ?? throw new ArgumentException(nameof(roleManager));
        }

        public void Seed(List<(string username, string password, string email)> accounts)
        {
            MedicIdentityContext.Database.Migrate();

            if (accounts == default || accounts.Count < 1)
            {
                throw new ArgumentException(nameof(accounts));
            }

            if (!RoleManager.Roles.Any(r => EF.Functions.Like(r.Name, MedicIdentityConstants.Administrator)))
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = MedicIdentityConstants.Administrator
                };

                Task task = RoleManager.CreateAsync(identityRole);

                task.Wait();
            }

            if (!UserManager.Users.Any())
            {
                IdentityUser identityUser;

                foreach ((string username, string password, string email) in accounts)
                {
                    if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
                    {
                        throw new ArgumentException($"{nameof(username)} : {username} - {nameof(password)} : {password} - {nameof(email)} : {email}");
                    }

                    identityUser = new IdentityUser()
                    {
                        UserName = username,
                        Email = email
                    };

                    Task<IdentityResult> result = UserManager.CreateAsync(identityUser, password);

                    if (!result.Result.Succeeded)
                    {
                        throw new Exception($"{nameof(identityUser)} - {identityUser.UserName} - {identityUser.Email}");
                    }

                    Task<IdentityResult> roleResult = UserManager.AddToRoleAsync(identityUser, MedicIdentityConstants.Administrator);

                    if (!roleResult.Result.Succeeded)
                    {
                        throw new Exception($"Add role to {identityUser.UserName} - {identityUser.Email}");
                    }
                }
            }
        }
    }
}
