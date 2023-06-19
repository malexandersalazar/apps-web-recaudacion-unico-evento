using Microsoft.AspNetCore.Identity;

namespace UniqueFundraisingEvent.Web
{
    public static class SeedIdentity
    {
        public static async Task Seed(this IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = new string[] { "Administrador", "Recepcionista", "Recolector" };

            foreach (string role in roles)
            {
                if (await roleManager.FindByNameAsync(role) is null)
                {
                    var identityRole = new IdentityRole(role);
                    await roleManager.CreateAsync(identityRole);
                }
            }

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var accounts = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("administrador10","[P@ssw0rd01]"),
                new KeyValuePair<string, string>("administrador20","[P@ssw0rd02]"),
                new KeyValuePair<string, string>("administrador30","[P@ssw0rd03]"),
                new KeyValuePair<string, string>("recepcionista10","[P@ssw0rd04"),
                new KeyValuePair<string, string>("recepcionista20","[P@ssw0rd05]"),
                new KeyValuePair<string, string>("recepcionista30","[P@ssw0rd06]"),
                new KeyValuePair<string, string>("recolector10","[P@ssw0rd07]"),
                new KeyValuePair<string, string>("recolector20","[P@ssw0rd08]"),
                new KeyValuePair<string, string>("recolector30","[P@ssw0rd09]"),
            };

            foreach (var account in accounts)
            {
                if (await userManager.FindByNameAsync(account.Key) is null)
                {
                    var identityUser = Activator.CreateInstance<IdentityUser>();
                    await userManager.SetUserNameAsync(identityUser, account.Key);
                    var identityResult = await userManager.CreateAsync(identityUser, account.Value);

                    if (!identityResult.Succeeded)
                        throw new Exception(identityResult.Errors.First().Description);

                    if (account.Key.Contains("administrador"))
                        await userManager.AddToRoleAsync(identityUser, "Administrador");
                    else if (account.Key.Contains("recepcionista"))
                        await userManager.AddToRoleAsync(identityUser, "Recepcionista");
                    else
                        await userManager.AddToRoleAsync(identityUser, "Recolector");
                }
            }
        }
    }
}