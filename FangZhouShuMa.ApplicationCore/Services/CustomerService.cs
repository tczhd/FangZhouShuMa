using Ardalis.GuardClauses;
using FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate;
using FangZhouShuMa.ApplicationCore.Interfaces;
using FangZhouShuMa.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FangZhouShuMa.ApplicationCore.Services
{
    public class CustomerService :ICustomerService
    {
        private readonly IAsyncRepository<Account> _accountRepository;

        public CustomerService(IAsyncRepository<Account> accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<Account> CreateCustomerAccountAsync(string companyName, Customer customer)
        {
            Guard.Against.Null(customer, nameof(customer));

            var account = new Account() {
                AccountGroupId = 1,
                Active = true,
                Address = customer.Address,
                City = customer.City,
                Customers = new List<Customer>() {customer },
                CountryId = customer.CountryId,
                Email = customer.Email,
                FirstName = customer.FirstName,
                JoinDateUTC = customer.JoinDateUTC,
                LastUpdatedUTC = customer.LastUpdatedUTC,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                HouseAccount = true,
                Name = companyName,
                StateName = customer.StateName,
                Zip = customer.Zip,
                CreditLimit = 0,
                TaxException = true
           
            };

           return  await _accountRepository.AddAsync(account);
        }
    }
}
