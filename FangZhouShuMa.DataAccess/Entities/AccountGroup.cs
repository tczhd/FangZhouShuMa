using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.DataAccess.Entities
{
    public class AccountGroup
    {
        public AccountGroup()
        {
            Accounts = new HashSet<Account>();
        }

        public int AccountGroupId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int SalesChannelId { get; set; }

        public bool Active { get; set; }

        public virtual SalesChannel SalesChannel { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
