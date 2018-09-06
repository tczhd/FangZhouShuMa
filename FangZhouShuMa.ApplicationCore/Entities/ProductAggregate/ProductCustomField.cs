using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FangZhouShuMa.ApplicationCore.Entities.ProductAggregate
{
    public class ProductCustomField : BaseEntity
    {
        public ProductCustomField()
        {
            ProductCustomFieldOptions = new HashSet<ProductCustomFieldOption>();
            ProductCustomFieldData = new HashSet<ProductCustomFieldData>();
        }
        public int ProductCustomFieldGroupId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int FieldTypeId { get; set; }

        public int MaxLength { get; set; }

        public int Sequence { get; set; }

        public bool Active { get; set; }

        public DateTime LastUpdateDateUTC { get; set; }
        public virtual ProductCustomFieldGroup ProductCustomFieldGroup { get; set; }
        public virtual ICollection<ProductCustomFieldOption> ProductCustomFieldOptions { get; set; }
        public virtual ICollection<ProductCustomFieldData> ProductCustomFieldData { get; set; }
    }
}
