using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Models.ProductReport
{
    public class ProductCustomFieldModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int FieldTypeId { get; set; }

        public List<ProductCustomFieldModel> ProductCustomFieldModels { get; set; }

        public List<ProductCustomFieldOptionModel> ProductCustomFieldOptionModels { get; set; }
    }
}
