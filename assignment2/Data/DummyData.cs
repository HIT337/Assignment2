﻿using assignment2.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2.Data
{
    public class DummyData
    {
        public static async Task Initialize(ApplicationDbContext context,
                              UserManager<ApplicationUser> userManager,
                              RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId1 = "";

            string role1 = "Admin";
            string desc1 = "This is the administrator role";

            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(role1) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role1, desc1, DateTime.Now));
            }

            if (await userManager.FindByNameAsync("a") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "a@a.a",
                    Email = "a@a.a",
                    FirstName = "Adam",
                    LastName = "Aldridge",
                    City = "Vancouver",
                    PostalCode = "V5U K8I",
                    Country = "Canada",
                    PhoneNumber = "6902341234"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role1);
                }
                adminId1 = user.Id;
            }
        }
    }
}
