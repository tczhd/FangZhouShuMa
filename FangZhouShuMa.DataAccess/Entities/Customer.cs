using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FangZhouShuMa.DataAccess.Entities
{
    public class Customer
    {
        public Customer()
        {
            ShippingInfos = new HashSet<ShippingInfo>();
            Orders = new HashSet<Order>();
        }
        public int CustomerId { get; set; }
        public int AccountId { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public DateTime JoinDateUTC { get; set; }

        [Required]
        [StringLength(350)]
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
        [StringLength(100)]
        public string StateName { get; set; }
        [Required]
        public int CountryId { get; set; }

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
        public int? SalesPersonId { get; set; }
        public bool Active { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }
        public DateTime LastUpdatedUTC { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        public virtual AspNetUsers AspNetUser { get; set; }

        public virtual Account Account { get; set; }

        public virtual ICollection<ShippingInfo> ShippingInfos { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
