using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.Infrastructure.Entities
{
    public class AspNetUsers: IdentityUser
    {
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
