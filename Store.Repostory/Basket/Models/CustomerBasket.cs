using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repostory.Basket.Models
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public int? DeliveryMethod { get; set; }
        public decimal ShipingPrice { get; set; }
        public List<BasketIttem> BasketItem { get; set; }=new List<BasketIttem>();
    }
}
