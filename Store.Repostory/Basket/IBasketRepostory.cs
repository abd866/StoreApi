using Store.Repostory.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repostory.Basket
{
    public interface IBasketRepostory
    {
        Task<CustomerBasket> GetBasketAsync(string id);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customer);
        Task<bool> DeleteBasketAsync(string id);
    }
}
