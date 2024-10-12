using AutoMapper;
using Store.Repostory.Basket;
using Store.Repostory.Basket.Models;
using Store.Services.BasketServices.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepostory _basketRepostory;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepostory basketRepostory,IMapper mapper)
        {
            _basketRepostory = basketRepostory;
            _mapper = mapper;
        }
        public  async Task<bool> DeleteBasketAsync(string id)
          => await _basketRepostory.DeleteBasketAsync(id);

        public async Task<CustomerBasketDTO> GetBasketAsync(string id)
        {
            var basket =_basketRepostory.GetBasketAsync(id);
            if(basket == null)
                return new CustomerBasketDTO();
            var mapedBasket=_mapper.Map<CustomerBasketDTO>(basket);
            return mapedBasket;
        }

        public async Task<CustomerBasketDTO> UpdateBasketAsync(CustomerBasketDTO customer)
        {
            if (customer.Id is null)
                customer.Id= GnerateBasketIdRandom();
            var custumerBasket=_mapper.Map<CustomerBasket>(customer);
            var updetedBasket=await _basketRepostory.UpdateBasketAsync(custumerBasket);
            var mapedBasket=_mapper.Map<CustomerBasketDTO>(updetedBasket);
            return mapedBasket;
        }
        private string GnerateBasketIdRandom()
        {
            Random rnd = new Random();
            int randomId = rnd.Next(1000, 10000);

            return $"BS-{randomId}";
        }
    }
}
