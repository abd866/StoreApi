using Microsoft.AspNetCore.Identity;
using Store.Data.Context;
using Store.Data.Entities.IdentityEntity;

namespace Store.Web.Extentions
{
    public static class IdenitityServiceExtention
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        { 
          var builder=services.AddIdentityCore<AppUser>();
            builder=new IdentityBuilder(builder.UserType,builder.Services);
            builder.AddEntityFrameworkStores<StoreIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppUser>>();
            services.AddAuthentication();
            return services;
        
        }
    }
}
