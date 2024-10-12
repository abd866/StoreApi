using Store.Repostory.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.BasketServices.Dto
{
      public class CustomerBasketDTO
    {
        public string? Id { get; set; }
        public int? DeliveryMethod { get; set; }
        public decimal ShipingPrice { get; set; }
        public List<BasketIttemDTO> BasketItem { get; set; } = new List<BasketIttemDTO>();
    }
}
