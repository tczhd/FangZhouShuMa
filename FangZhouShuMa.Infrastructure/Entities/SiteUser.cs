using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.Infrastructure.Entities
{
    public class SiteUser
    {
        public SiteUser()
        {
            CreatedOrders = new HashSet<Order>();
            EditOrders = new HashSet<Order>();
        }
        public int SiteUserId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public bool Active { get; set; }
        public virtual ICollection<Order> CreatedOrders { get; set; }
        public virtual ICollection<Order> EditOrders { get; set; }
    }
}
