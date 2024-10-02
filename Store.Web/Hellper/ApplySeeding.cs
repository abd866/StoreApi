using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Repostory;

namespace Store.Web.Hellper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedindAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            { 
             var services= scope.ServiceProvider;
                var loggerF= services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context=services.GetRequiredService<StoreDBContext>();
                    await context.Database.MigrateAsync();
                    await StoreContextSeed.SeedDataAsync(context, loggerF);

                }
                catch (Exception ex)
                {
                    var logger = loggerF.CreateLogger<ApplySeeding>();
                    logger.LogError(ex.Message);
                }
            
            
            
            }

        }

    }
}
