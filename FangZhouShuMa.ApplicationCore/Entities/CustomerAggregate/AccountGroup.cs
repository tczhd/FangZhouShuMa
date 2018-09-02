using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate
{
    public class AccountGroup : BaseEntity
    {
        public AccountGroup()
        {
            Accounts = new HashSet<Account>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int SalesChannelId { get; set; }

        public bool Active { get; set; }

        public virtual SalesChannel SalesChannel { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
