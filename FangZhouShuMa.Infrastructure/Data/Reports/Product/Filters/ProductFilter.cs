using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.Infrastructure.Data.Reports.Product.Filters
{
    public class ProductFilter
    {
        public int? ProductId { get; set; }

        public ProductFilter(int id)
        {
            ProductId = id;
        }
    }
}
