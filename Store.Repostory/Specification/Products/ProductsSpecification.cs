using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repostory.Specification.Products
{
    public class ProductsSpecification
    {
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }
        public string? sort { get; set; }
        public int? pageIndex { get; set; } = 1;
        private const int  MaxPageSize = 50;
        private int _pageSize=10;

        public int pagesize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ?int.MaxValue:value;
        }
        private string? _search;

        public string? search
        {
            get =>_search;
            set => _search = value?.Trim().ToLower();
        }

    }
}
