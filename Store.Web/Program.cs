
using Microsoft.EntityFrameworkCore;
using Store.Data.Context;
using Store.Repostory.Interfaces;
using Store.Repostory.Repostory;
using Store.Services.Products;
using Store.Services.Products.DTO;
using Store.Web.Hellper;

namespace Store.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
            });
            builder.Services.AddScoped<IUintOfWork, UintOfWork>();
            builder.Services.AddAutoMapper(typeof(ProductProfile));
            builder.Services.AddScoped<IProductServices, ProductServices>();   
            var app = builder.Build();
            await ApplySeeding.ApplySeedindAsync(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
