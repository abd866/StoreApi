using Store.Repostory.Basket.Models;
using Store.Services.BasketServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.BasketServices
{
    public interface IBasketService
    {
        Task<CustomerBasketDTO> GetBasketAsync(string id);
        Task<CustomerBasketDTO> UpdateBasketAsync(CustomerBasketDTO customer);
        Task<bool> DeleteBasketAsync(string id);
    }
}
