using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.Infrastructure.Entities
{
    public class Account
    {
        public Account()
        {
            Customers = new HashSet<Customer>();
        }
        public int AccountId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(350)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Zip { get; set; }

        [Required]
        [StringLength(30)]
        public string PhoneNumber { get; set; }

        [StringLength(20)]
        public string PhoneNumberExt { get; set; }

        [StringLength(30)]
        public string FaxNumber { get; set; }

        [StringLength(20)]
        public string FaxNumberExt { get; set; }

        [StringLength(30)]
        public string CellNumber { get; set; }

        public int? CreditTerms { get; set; }

        public decimal CreditLimit { get; set; }

        public DateTime JoinDateUTC { get; set; }

        public bool TaxException { get; set; }

        public bool HouseAccount { get; set; }

        public bool Active { get; set; }

        public int AccountGroupId { get; set; }

        public int CountryId { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }
        public DateTime LastUpdatedUTC { get; set; }

        public virtual AccountGroup AccountGroup { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
