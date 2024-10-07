using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Repostory.Specification.Products;
using Store.Services.Products;
using Store.Services.Products.DTO;
using Store.Web.Hellper;

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
        [Cache(10)]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDTO>>> GetAllBrand()
            => Ok(await _productServices.GetAllPrandsAsync());

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDTO>>> GetAllTypes()
            => Ok(await _productServices.GetAllTypesAsync());

        [HttpGet]
        public async Task<ActionResult<ProductDetailsDTO>> GetProductById(int? Id)
               => Ok(await _productServices.GetProductByIdAsync(Id));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDTO>>> GetAllProduct([FromQuery]ProductsSpecification spec)
            => Ok(await _productServices.GetAllProductsAsync(spec));
    }
}
