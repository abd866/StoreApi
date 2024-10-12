using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.IdentityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repostory
{
    public class StoreIdentiyContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplyName = "Abdullah Fayed",
                    Email = "Abdullah.fayed43@Gmail.com",
                    UserName = "fayed44",
                    Address = new Address
                    {
                        FristName = "Abdullah",
                        LastName = "fayed",
                        City = "Atfih",
                        State = "Giza",
                        Street = "3",
                        PostalCode = "12345",
                    }
                };
                await userManager.CreateAsync(user,"Password123!");
            }
        }
    }
}
