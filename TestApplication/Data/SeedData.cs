using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApplication.Models;

namespace TestApplication.Data
{
    public class SeedData
    {
        public async static Task Initialize(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] Roles = { "ADMIN","USER" };

            foreach(var role in Roles)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            ApplicationUser applicationUser = await userManager.FindByNameAsync("admin");

            if (applicationUser == null)
            {

                applicationUser = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@admin.com",
                    Address = "Kathmandu"
                };

                var res = await userManager.CreateAsync(applicationUser, "Admin@123");

                if (res.Succeeded)
                {
                    await userManager.AddToRoleAsync(applicationUser, "ADMIN");
                }
               
            }
        }
    }
}
