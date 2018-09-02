using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Entities.ProductAggregate
{
    public class ProductCustomFieldGroup : BaseEntity
    {
        public ProductCustomFieldGroup()
        {
            ProductCustomFields = new HashSet<ProductCustomField>();
        }

        public string Name { get; set; }
        public virtual ICollection<ProductCustomField> ProductCustomFields { get; set; }
    }
}
