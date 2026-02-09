using Microsoft.AspNetCore.Identity;
using MathTestSystem.Domain.Entities;

public static class SeedData
{
    public static async Task SeedUsers(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        if (!await roleManager.RoleExistsAsync("Teacher"))
            await roleManager.CreateAsync(new IdentityRole("Teacher"));
        if (!await roleManager.RoleExistsAsync("Student"))
            await roleManager.CreateAsync(new IdentityRole("Student"));

        if (await userManager.FindByNameAsync("williamTeacher") == null)
        {
            var user = new ApplicationUser
            {
                UserName = "williamTeacher",
                Email = "william@teacher.com",
                ProfileId = 1,
                Role = "Teacher"
            };
            await userManager.CreateAsync(user, "Teacher123!");
            await userManager.AddToRoleAsync(user, "Teacher");
        }

        if (await userManager.FindByNameAsync("anaStudent") == null)
        {
            var user = new ApplicationUser
            {
                UserName = "anaStudent",
                Email = "ana@student.com",
                ProfileId = 1,
                Role = "Student"
            };
            await userManager.CreateAsync(user, "AnaStudent123!");
            await userManager.AddToRoleAsync(user, "Student");
        }

        if (await userManager.FindByNameAsync("johnStudent") == null)
        {
            var user = new ApplicationUser
            {
                UserName = "johnStudent",
                Email = "john@student.com",
                ProfileId = 2,
                Role = "Student"
            };
            await userManager.CreateAsync(user, "JohnStudent123!");
            await userManager.AddToRoleAsync(user, "Student");
        }
    }
}
