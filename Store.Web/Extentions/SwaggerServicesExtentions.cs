using Microsoft.OpenApi.Models;
using System.Collections;

namespace Store.Web.Extentions
{
    public static class SwaggerServicesExtentions
    {
        public static IServiceCollection  AddSwaggerDocumentaion(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Store Api",
                    Version = "v1",
                    Contact=new OpenApiContact
                    {
                        Name= "Abdullah",
                        Email="abdullah.fayed43@gmail.com",

                    }
                });
                var securitySecema = new OpenApiSecurityScheme
                {
                    Description = "test",
                    Name = "Authorazation",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Id="bearer",
                        Type=ReferenceType.SecurityScheme
                    }
                };
                options.AddSecurityDefinition("bearer", securitySecema);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {securitySecema,new[]{"bearer"} }
                };
                options.AddSecurityRequirement(securityRequirement);    
            });
            return services;
        }
    }
}
