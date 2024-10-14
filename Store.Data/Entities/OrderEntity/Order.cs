using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities.OrderEntity
{
    public class Order:BaseEntity<Guid>
    {
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderTime { get; set; }= DateTimeOffset.Now;
        public ShippingAdress ShippingAdress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public int? DeliveryMethodId { get; set; }
        public OrderStuates OrderStuates { get;set; }=OrderStuates.Placed;
        public OrderPayment OrderPayment { get; set; } = OrderPayment.pinding;
        public IReadOnlyList<OrderItem> Items { get; set;} = new List<OrderItem>();
        public decimal SubTotal { get; set; }
        public decimal GetTotal()=>SubTotal+ DeliveryMethod.Price;
        public string?  BasketId { get; set; }
    }
}
