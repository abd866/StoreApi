using Microsoft.AspNetCore.Mvc;
using Store.Repostory.Interfaces;
using Store.Repostory.Repostory;
using Store.Services.Cahe;
using Store.Services.HandlleResponse;
using Store.Services.Products.DTO;

namespace Store.Web.Extentions
{
    public static class ApplicationServicesEtentions
    {
        public static IServiceCollection ApplicationServicesCollections(this IServiceCollection services) {
          
            services.AddScoped<IUintOfWork, UintOfWork>();
            services.AddScoped<IcacheIServices, CacheIServices>();
            services.AddAutoMapper(typeof(ProductProfile));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var error = actionContext.ModelState
                    .Where(model => model.Value?.Errors.Count() > 0)
                    .SelectMany(model => model.Value?.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                    var responsError = new ValditionErrorRespons
                    {
                        Errors = error
                    };
                    return new BadRequestObjectResult(responsError);
                };
            });
            return services;


        }
    }
}
