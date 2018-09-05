using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.ApiModels.Product
{
    public class ProductCustomFieldGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductCustomFieldData> ProductCustomFieldDataList { get; set; }
    }
}
