using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entities.OrderEntity
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ProductItem ProductItem { get; set; }
        public Guid OrderId { get; set; }
    }
}
