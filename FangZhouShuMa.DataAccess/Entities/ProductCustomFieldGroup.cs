using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.DataAccess.Entities
{
    public class ProductCustomFieldGroup
    {
        public ProductCustomFieldGroup()
        {
            ProductCustomFields = new HashSet<ProductCustomField>();
        }
        public int ProductCustomFieldGroupId { get;set;}
        public string Name { get; set; }
        public virtual ICollection<ProductCustomField> ProductCustomFields { get; set; }
    }
}
