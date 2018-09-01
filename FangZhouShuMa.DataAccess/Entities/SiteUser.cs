using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.DataAccess.Entities
{
    public class SiteUser
    {
        public SiteUser()
        {
            Orders = new HashSet<Order>();
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
        public virtual ICollection<Order> Orders { get; set; }
    }
}
