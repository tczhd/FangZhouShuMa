using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.ApplicationCore.Entities.ProductAggregate
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ProductCustomFieldData = new HashSet<ProductCustomFieldData>();
        }
        public int GroupId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool Taxable { get; set; }

        public int Sequence { get; set; }

        public bool Active { get; set; }

        public decimal MinumumQuantity { get; set; }
        public bool MultipleMinumumQuantity { get; set; }
        public decimal Cost { get; set; }

        [StringLength(250)]
        public string UPC { get; set; }

        public DateTime CreateDateUTC { get; set; }

        public DateTime LastUpdateDateUTC { get; set; }

        public int UpdatedBy { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<ProductCustomFieldData> ProductCustomFieldData { get; set; }
    }
}
