using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Products.DTO
{
    public class ProductPictureReslover : IValueResolver<Product, ProductDetailsDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureReslover(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDetailsDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl)) 
                return $"{_configuration["BaseUrl"]}/{source.PictureUrl}";
            return null;
        }
    }
}
