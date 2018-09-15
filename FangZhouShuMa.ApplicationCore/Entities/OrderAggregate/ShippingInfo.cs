using FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte
{
    public class ShippingInfo : BaseEntity
    {
        public int OrderId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(200)]
        public string Company { get; set; }

        [Required]
        [StringLength(250)]
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
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string PhoneExt { get; set; }

        public int CountryId { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }

        [StringLength(200)]
        public string StoreName { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public int ShippingMethodId { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }

        public virtual Order Order { get; set; }
    }
}
