using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FangZhouShuMa.Infrastructure.Identity
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "Amin@FangZhuShuMa.com", Email = "admin@fangzhoushuma.com" };
            await userManager.CreateAsync(defaultUser, "Lq160011!");
        }
    }
}
