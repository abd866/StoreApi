using AutoMapper;
using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Products.DTO
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDetailsDTO>().
                ForMember(des => des.BrandName, option => option.MapFrom(src => src.Brand.Name))
                .ForMember(des => des.TypeName, option => option.MapFrom(src => src.type.Name))
                .ForMember(des => des.PictureUrl, option => option.MapFrom<ProductPictureReslover>());
            CreateMap<ProductBrand, BrandTypeDTO>().ReverseMap();
            CreateMap<ProductType, BrandTypeDTO>();
        }
    }
}
