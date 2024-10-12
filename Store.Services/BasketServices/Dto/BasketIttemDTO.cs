using System.ComponentModel.DataAnnotations;

namespace Store.Services.BasketServices.Dto
{
    public class BasketIttemDTO
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(0.1, double.MaxValue,ErrorMessage ="Price Must Be Greater Than Zero")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage = "Quantity Must Be Greater Than Zero")]
        public int Quantity { get; set; }
        [Required]
        public string PicutreUrl { get; set; }
        [Required]
        public string BrandName { get; set; }
        public string TypeName { get; set; }
    }
}