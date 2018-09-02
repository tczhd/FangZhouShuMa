using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.Infrastructure.Entities
{
    public class ProductCustomFieldOptionsDisplayByRelationship
    {
        public int ProductCustomFieldOptionsDisplayByRelationshipId { get; set; }
        public int ProductCustomFieldPrimaryOptionsId { get; set; }
        public int ProductCustomFieldDisplayOptionsId { get; set; }
        public virtual ProductCustomFieldOption ProductCustomFieldOptionPrimary { get; set; }
        public virtual ProductCustomFieldOption ProductCustomFieldOptionDisplay { get; set; }
    }
}
