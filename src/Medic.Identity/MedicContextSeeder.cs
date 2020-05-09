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

        public async Task Seed(List<(string username, string password, string email)> accounts)
        {
            MedicIdentityContext.Database.EnsureCreated();

            if (accounts == default || accounts.Count < 1)
            {
                throw new ArgumentException(nameof(accounts));
            }

            if (!RoleManager.Roles.Any(r => EF.Functions.Like(r.Name, "Administrator")))
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = "Administrator"
                };

                await RoleManager.CreateAsync(identityRole);
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

                    IdentityResult result = await UserManager.CreateAsync(identityUser, password);

                    if (!result.Succeeded)
                    {
                        throw new Exception($"{nameof(identityUser)} - {identityUser.UserName} - {identityUser.Email}");
                    }

                    IdentityResult roleResult = await UserManager.AddToRoleAsync(identityUser, "Administrator");

                    if (!roleResult.Succeeded)
                    {
                        throw new Exception($"Add role to {identityUser.UserName} - {identityUser.Email}");
                    }
                }
            }
        }
    }
}
