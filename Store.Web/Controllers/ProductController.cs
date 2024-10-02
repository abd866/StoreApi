using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Products;
using Store.Services.Products.DTO;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDTO>>> GetAllBrand()
            => Ok(await _productServices.GetAllPrandsAsync());

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDTO>>> GetAllTypes()
            => Ok(await _productServices.GetAllTypesAsync());

        [HttpGet]
        public async Task<ActionResult<ProductDetailsDTO>> GetProductById(int? Id)
               => Ok(await _productServices.GetProductByIdAsync(Id));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDTO>>> GetAllProduct()
            => Ok(await _productServices.GetAllProductsAsync());
    }
}
