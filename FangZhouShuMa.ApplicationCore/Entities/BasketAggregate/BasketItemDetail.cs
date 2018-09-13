using System;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.ApplicationCore.Entities.BasketAggregate
{
    public class BasketItemDetail : BaseEntity
    {
        public int BasketItemId { get; set; }
        public int ProductCustomFieldGroupId { get; set; }
        [Required]
        public string ProductCustomFieldGroupName { get; set; }

        public int ProductCustomFieldId { get; set; }
        [Required]
        public string ProductCustomFieldName { get; set; }
        public int ProductCustomFieldTypeId { get; set; }
        public int? ProductCustomFieldOptionId { get; set; }
        [Required]
        public string ProductCustomFieldData { get; set; }
        [Required]
        public string ProductCustomFieldDataDescription { get; set; }
    }
}
