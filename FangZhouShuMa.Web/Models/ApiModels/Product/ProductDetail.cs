using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.ApiModels.Product
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal MinumumQuantity { get; set; }
        public DateTime CreateDateUTC { get; set; }
        public DateTime LastUpdateDateUTC { get; set; }
        public List<ProductCustomFieldGroup> ProductCustomFieldGroup { get; set; }
    }
}
