using System;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.ApplicationCore.Entities.BasketAggregate
{
    public class BasketItemDetail : BaseEntity
    {
        public int BasketItemId { get; set; }
        public int ProductCustomFieldGroupId { get; set; }
        [Required]
        [StringLength(150)]
        public string ProductCustomFieldGroupName { get; set; }

        public int ProductCustomFieldId { get; set; }
        [Required]
        [StringLength(150)]
        public string ProductCustomFieldName { get; set; }
        public int ProductCustomFieldTypeId { get; set; }
        public int? ProductCustomFieldOptionId { get; set; }
        [Required]
        [StringLength(150)]
        public string ProductCustomFieldData { get; set; }
        [Required]
        [StringLength(300)]
        public string ProductCustomFieldDataDescription { get; set; }
    }
}
