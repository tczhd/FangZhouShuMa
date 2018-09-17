using FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Specifications
{
    public class CustomerSpecification : BaseSpecification<Customer>
    {
        public CustomerSpecification(string userId)
          : base(i => i.UserId == userId)
        {
        }
    }
}
