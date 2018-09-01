using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FangZhouShuMa.DataAccess.Entities
{
    public class ProductCustomField
    {
        public ProductCustomField()
        {
            ProductCustomFieldOptions = new HashSet<ProductCustomFieldOption>();
        }
        public int ProductCustomFieldId { get; set; }
        public int ProductCustomFieldGroupId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public int FieldTypeId { get; set; }

        public int MaxLength { get; set; }

        public int Sequence { get; set; }

        public bool Active { get; set; }

        public DateTime LastUpdateDateUTC { get; set; }
        public virtual ProductCustomFieldGroup ProductCustomFieldGroup { get; set; }
        public virtual ICollection<ProductCustomFieldOption> ProductCustomFieldOptions { get; set; }
    }
}
