using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate
{
    public class SalesChannel : BaseEntity
    {
        public SalesChannel()
        {
            AccountGroups = new HashSet<AccountGroup>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<AccountGroup> AccountGroups { get; set; }
    }
}
