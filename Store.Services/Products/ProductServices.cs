using AutoMapper;
using Store.Data.Entities;
using Store.Repostory.Interfaces;
using Store.Services.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Products
{
    public class ProductServices : IProductServices
    {
        private readonly IUintOfWork _uintOfWork;
        private readonly IMapper _mapper;

        public ProductServices(IUintOfWork uintOfWork,IMapper mapper)
        {
            _uintOfWork = uintOfWork;
            _mapper = mapper;
        }
        public async  Task<IReadOnlyList<BrandTypeDTO>> GetAllPrandsAsync()
        {
            var brands= await _uintOfWork.Repostory<ProductBrand,int>().GetAllAsync();
            var mappedBrand=  _mapper.Map< IReadOnlyList<BrandTypeDTO>> (brands);
            return mappedBrand;
        }

        public async  Task<IReadOnlyList<ProductDetailsDTO>> GetAllProductsAsync()
        {
            var Product  = await _uintOfWork.Repostory<Product, int>().GetAllAsync();
            var mappedProduct = _mapper.Map<IReadOnlyList<ProductDetailsDTO>>(Product);
            return mappedProduct;
        }

        public  async Task<IReadOnlyList<BrandTypeDTO>> GetAllTypesAsync()
        {
            var Types = await _uintOfWork.Repostory<ProductBrand, int>().GetAllAsync();
            var mappedTypes = _mapper.Map<IReadOnlyList<BrandTypeDTO>>(Types);
            return mappedTypes;
        }

        public async Task<ProductDetailsDTO> GetProductByIdAsync(int? id)
        {
            if(id is null)
                throw new Exception("Id is null");
            var product =await _uintOfWork.Repostory<Product,int>().GetByIdAsync(id.Value);
            var mappedProduct=_mapper.Map<ProductDetailsDTO>(product);
            return mappedProduct;
        }
    }
}
