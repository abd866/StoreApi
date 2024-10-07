using Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repostory.Specification.Products
{
    public class ProductsWithSpecification:BaseSpecification<Product>
    {
        public ProductsWithSpecification(ProductsSpecification specs)
            : base(product => (!specs.BrandId.HasValue || product.BrandId == specs.BrandId.Value) &&
                              (!specs.TypeId.HasValue || product.TypeId == specs.TypeId.Value)&&
                              (string.IsNullOrEmpty(specs.search)|| product.Name.Trim().ToLower().Contains(specs.search))
            )   
        {

            AddIncluded(x=>x.Brand);
            AddIncluded(x => x.Type);
            AddOrderBy(x=>x.Name);
            ApplyPaginaging((int)(specs.pagesize * (specs.pageIndex - 1)), specs.pagesize);

            if (!string.IsNullOrEmpty(specs.sort))
            {
                switch (specs.sort)
                {
                    case "ProductPrice":
                        AddOrderBy(x=>x.Price);
                        break;
                    case "ProductPriceDes":
                        AddOrderByDes(x => x.Price);
                        break;
                        default:
                        AddOrderBy(x => x.Name);
                        break;


                }
            }

        }
        public ProductsWithSpecification(int?id) : base(product => product.Id==id  )
        {

            AddIncluded(x => x.Brand);
            AddIncluded(x => x.Type);


        }
    }
}
