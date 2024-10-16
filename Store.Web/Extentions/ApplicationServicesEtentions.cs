﻿using Microsoft.AspNetCore.Mvc;
using Store.Repostory.Basket;
using Store.Repostory.Interfaces;
using Store.Repostory.Repostory;
using Store.Services.BasketServices;
using Store.Services.BasketServices.Dto;
using Store.Services.Cahe;
using Store.Services.HandlleResponse;
using Store.Services.Products.DTO;
using Store.Services.TokenServices;
using Store.Services.UserServices;

namespace Store.Web.Extentions
{
    public static class ApplicationServicesEtentions
    {
        public static IServiceCollection ApplicationServicesCollections(this IServiceCollection services) {
          
            services.AddScoped<IUintOfWork, UintOfWork>();
            services.AddScoped<IcacheIServices, CacheIServices>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IBasketRepostory, BasketRepostory>();
            services.AddScoped<ITokenServices, TokenServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddAutoMapper(typeof(BasketProfile));
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
