using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Models.ProductReport
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDateUTC { get; set; }

        public DateTime LastUpdateDateUTC { get; set; }
 
        public List<ProductCustomFieldGroupModel> ProductCustomFieldGroupModels { get; set; }
    }
}
