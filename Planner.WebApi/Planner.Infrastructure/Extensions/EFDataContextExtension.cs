using Microsoft.AspNetCore.Identity;
using Planner.Application.Constants;
using Planner.Domain;
using Planner.EFData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Planner.Infrastructure.Extensions
{
    public static class EFDataContextExtension
    {
        public static void EnsureSeeder(this DataContext context,
            UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            CreateDefaultRoles(roleManager);
            CreateDefaultUsers(userManager);
        }
        private static void CreateDefaultRoles(RoleManager<AppRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                var result = roleManager.CreateAsync(new AppRole
                {
                    Name = Roles.Admin
                }).Result;
                if (!result.Succeeded)
                {
                    throw new ApplicationException($"Defalut role `{Roles.Admin}` cannot be created");
                }
                result = roleManager.CreateAsync(new AppRole
                {
                    Name = Roles.User
                }).Result;
                if (!result.Succeeded)
                {
                    throw new ApplicationException($"Defalut role `{Roles.User}` cannot be created");
                }
            }
        }
        private static void CreateDefaultUsers(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                AppUser admin = new AppUser()
                {
                    DisplayName = "Admin",
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    PhoneNumber = "+380950000000"
                };
                var res = userManager.CreateAsync(admin, "Qwerty1-").Result;
                if (!res.Succeeded)
                {
                    var exception = new ApplicationException($"Default user `{admin.Email}` cannot be created");
                    throw exception;
                }

                res = userManager.AddToRoleAsync(admin, Roles.Admin).Result;

                AppUser user = new AppUser()
                {
                    DisplayName = "User",
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com",
                    PhoneNumber = "+38095000000"
                };
                res = userManager.CreateAsync(user, "Qwerty1+").Result;
                if (!res.Succeeded)
                {
                    var exception = new ApplicationException($"Default user `{user.Email}` cannot be created");
                    throw exception;
                }

                res = userManager.AddToRoleAsync(user, Roles.User).Result;
            }
        }
    }
}
