using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.DataAccess.Entities
{
    public class ProductCustomFieldOption
    {
        public ProductCustomFieldOption()
        {
            ProductCustomFieldOptionsDisplayByRelationshipPrimaries = new HashSet<ProductCustomFieldOptionsDisplayByRelationship>();
            ProductCustomFieldOptionsDisplayByRelationshipDisplays = new HashSet<ProductCustomFieldOptionsDisplayByRelationship>();
        }
        [Key]
        public int ProductCustomFieldOptionsId { get; set; }

        public int ProductCustomFieldId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int Sequence { get; set; }

        public bool Active { get; set; }
        public int? ParentOptionsId { get; set; }

        public bool DisplayByRelationship { get; set; }
        public virtual ProductCustomField ProductCustomField { get; set; }

        public virtual ICollection<ProductCustomFieldOptionsDisplayByRelationship> ProductCustomFieldOptionsDisplayByRelationshipPrimaries { get; set; }
        public virtual ICollection<ProductCustomFieldOptionsDisplayByRelationship> ProductCustomFieldOptionsDisplayByRelationshipDisplays { get; set; }
    }
}
