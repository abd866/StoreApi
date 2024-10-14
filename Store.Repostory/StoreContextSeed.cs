using Microsoft.Extensions.Logging;
using Store.Data.Context;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repostory
{
    public class StoreContextSeed
    {
        public static async Task SeedDataAsync(StoreDBContext Context,ILoggerFactory loggerFactory)
        {
            try
            {
                if (Context.ProductBrands !=null && !Context.ProductBrands.Any())
                {

                    var BrandsDta = File.ReadAllText("../Store.Repostory/SeedData/brands.json");
                    var brand = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsDta);
                    if (brand is not null)
                        await Context.ProductBrands.AddRangeAsync(brand);
                    await Context.SaveChangesAsync();

                }
                if (Context.ProductType != null && !Context.ProductType.Any())
                {

                    var BrandsType = File.ReadAllText("../Store.Repostory/SeedData/types.json");
                    var type = JsonSerializer.Deserialize<List<ProductType>>(BrandsType);
                    if (type is not null)
                        await Context.ProductType.AddRangeAsync(type);
                    await Context.SaveChangesAsync();

                }
                if (Context.Products != null && !Context.Products.Any())
                {

                    var ProductsDta = File.ReadAllText("../Store.Repostory/SeedData/products.json");
                    var product = JsonSerializer.Deserialize<List<Product>>(ProductsDta);
                    if (product is not null)
                        await Context.Products.AddRangeAsync(product);
                        await Context.SaveChangesAsync();

                }
                if (Context.DeliveryMethods != null && !Context.DeliveryMethods.Any())
                {

                    var DeliveryMethodDta = File.ReadAllText("../Store.Repostory/SeedData/delivery.json");
                    var data = JsonSerializer.Deserialize<List<DeliveryMethod>>(DeliveryMethodDta);
                    if (data is not null)
                        await Context.DeliveryMethods.AddRangeAsync(data);
                        await Context.SaveChangesAsync();

                }
                await Context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            var logger=loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
