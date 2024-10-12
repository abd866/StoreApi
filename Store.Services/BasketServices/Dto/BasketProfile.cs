using AutoMapper;
using Store.Repostory.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.BasketServices.Dto
{
    public class BasketProfile:Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketIttem,BasketIttemDTO>().ReverseMap();
            CreateMap<CustomerBasket,CustomerBasketDTO>().ReverseMap();
        }
    }
}
