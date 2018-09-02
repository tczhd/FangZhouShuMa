using FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Entities.UserAggregate
{
    public class AspNetUser: IdentityUser
    {
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
