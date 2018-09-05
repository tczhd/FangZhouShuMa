using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FangZhouShuMa.Web.Models.ApiModels.Product
{
    public class ProductCustomFieldData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CustomFieldData { get; set; }
        public int FieldTypeId { get; set; }
        public List<ProductCustomFieldData> ProductCustomFieldDataList { get; set; }
        public List<ProductCustomFieldOption> ProductCustomFieldOptionList { get; set; }

    }
}
