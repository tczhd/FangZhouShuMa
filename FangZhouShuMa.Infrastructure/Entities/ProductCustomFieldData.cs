using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.Infrastructure.Entities
{
    public class ProductCustomFieldData
    {
        public int ProductCustomFieldDataId { get; set; }

        public int ProductId { get; set; }

        public int ProductCustomFieldId { get; set; }

        [Required]
        public string FieldData { get; set; }

        public DateTime LastUpdateDateUtc { get; set; }

        public virtual ProductCustomField ProductCustomField { get; set; }

        public virtual Product Product { get; set; }
    }
}
