using FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<Account> CreateCustomerAccountAsync(string companyName, Customer customer);
    }
}
