using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Entities.ProductAggregate
{
    public class ProductCustomFieldOptionsDisplayByRelationship : BaseEntity
    {

        public int ProductCustomFieldPrimaryOptionsId { get; set; }
        public int ProductCustomFieldDisplayOptionsId { get; set; }
        public virtual ProductCustomFieldOption ProductCustomFieldOptionPrimary { get; set; }
        public virtual ProductCustomFieldOption ProductCustomFieldOptionDisplay { get; set; }
    }
}
