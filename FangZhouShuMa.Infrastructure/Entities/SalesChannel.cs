using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.Infrastructure.Entities
{
    public class SalesChannel
    {
        public SalesChannel()
        {
            AccountGroups = new HashSet<AccountGroup>();
        }
        public int SalesChannelId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<AccountGroup> AccountGroups { get; set; }
    }
}
