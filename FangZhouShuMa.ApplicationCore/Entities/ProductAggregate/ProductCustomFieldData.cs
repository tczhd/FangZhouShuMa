using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.ApplicationCore.Entities.ProductAggregate
{
    public class ProductCustomFieldData : BaseEntity
    {

        public int ProductId { get; set; }

        public int ProductCustomFieldId { get; set; }

        [Required]
        public string FieldData { get; set; }

        public DateTime LastUpdateDateUtc { get; set; }

        public virtual ProductCustomField ProductCustomField { get; set; }

        public virtual Product Product { get; set; }
    }
}
