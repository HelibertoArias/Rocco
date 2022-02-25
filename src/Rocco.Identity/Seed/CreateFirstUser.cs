
using Microsoft.AspNetCore.Identity;
using Rocco.Identity.Models;
using System.Threading.Tasks;

namespace Rocco.Identity.Seed;

public static class CreateFirstUser
{
    public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
    {
        var applicationUser = new ApplicationUser
        {
            FirstName = "Heliberto",
            LastName = "Arias",
            UserName = "helibertoarias",
            Email = "helibertoarias@gmail.com",
            EmailConfirmed = true,

        };

        var user = await userManager.FindByEmailAsync(applicationUser.Email);
        if (user == null)
        {
            await userManager.CreateAsync(applicationUser, "P4assword@1");
        }
    }
}
