﻿namespace Store.Repostory.Basket.Models
{
    public class BasketIttem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int  Quantity { get; set; }
        public string PicutreUrl { get; set; }
        public string BrandName { get; set; }
        public string TypeName { get; set; }
    }
}