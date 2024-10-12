﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Services.BasketServices;
using Store.Services.BasketServices.Dto;

namespace Store.Web.Controllers
{

    public class Basketontroller : BaseController
    {
        private readonly IBasketService _basketService;

        public Basketontroller( IBasketService basketService)
        {
           _basketService = basketService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasketDTO>> GetBasketAsync(string id)
            => Ok(await _basketService.GetBasketAsync(id));
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDTO>> UpdateBasketAsync(CustomerBasketDTO basket)
      =>Ok( await _basketService.UpdateBasketAsync(basket));

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBasketAsync(string id)
                => Ok(await _basketService.DeleteBasketAsync(id));
    }
}
