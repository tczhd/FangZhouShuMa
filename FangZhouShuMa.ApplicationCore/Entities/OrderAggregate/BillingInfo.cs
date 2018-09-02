using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte
{
    public class BillingInfo : BaseEntity
    {

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Address2 { get; set; }

        [Required]
        [StringLength(50)]
        public string Zip { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string PhoneExt { get; set; }

        public int CountryId { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }

        public virtual Order Order { get; set; }
    }
}
