using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.DataAccess.Entities
{
    public class ProductCustomFieldOption
    {
        [Key]
        public int ProductCustomFieldOptionsId { get; set; }

        public int ProductCustomFieldId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int Sequence { get; set; }

        public bool Active { get; set; }
        public int? ProductCustomFieldRelatedOptionsId { get; set; }

        public virtual ProductCustomField ProductCustomField { get; set; }
    }
}
