using AutoMapper;
using Store.Data.Entities;
using Store.Repostory.Interfaces;
using Store.Repostory.Specification.Products;
using Store.Services.Hellper;
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

        public async  Task<PagingedRusltDTO<ProductDetailsDTO>> GetAllProductsAsync(ProductsSpecification input)
        {
            var spec=new ProductsWithSpecification(input);
            var Product  = await _uintOfWork.Repostory<Product, int>().GetWithSpecificationAllAsync(spec);
            var countSpecification = new ProductWithCountSpecification(input);
            var count = await _uintOfWork.Repostory<Product, int>().GetCountSpecifcationAsync(countSpecification);
            var mappedProduct = _mapper.Map<IReadOnlyList<ProductDetailsDTO>>(Product);
            return new PagingedRusltDTO<ProductDetailsDTO>((int)input.pageIndex,input.pagesize, count,mappedProduct);
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
            var specs= new ProductsWithSpecification(id);
            var product =await _uintOfWork.Repostory<Product,int>().GetWithSpecificationByIdAsync(specs);
            var mappedProduct=_mapper.Map<ProductDetailsDTO>(product);
            return mappedProduct;
        }
    }
}
