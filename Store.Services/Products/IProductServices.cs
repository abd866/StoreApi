using Store.Services.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Products
{
    public interface IProductServices
    {
        Task<ProductDetailsDTO> GetProductByIdAsync(int? id);
        Task<IReadOnlyList<ProductDetailsDTO>> GetAllProductsAsync();
        Task<IReadOnlyList<BrandTypeDTO>> GetAllPrandsAsync();
        Task<IReadOnlyList<BrandTypeDTO>> GetAllTypesAsync();
    }
}
