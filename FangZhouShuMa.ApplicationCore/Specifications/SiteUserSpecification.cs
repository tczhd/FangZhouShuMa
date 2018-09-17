using FangZhouShuMa.ApplicationCore.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Specifications
{
    public class SiteUserSpecification : BaseSpecification<SiteUser>
    {
        public SiteUserSpecification(string userId)
           : base(i => i.UserId == userId)
        {
        }
    }
}
