using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.DataAccess.Entities
{
    public class ShippingInfo
    {
        public int ShippingInfoId { get; set; }
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

        public bool IsRecipient { get; set; }

        public int CountryId { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }

        [StringLength(200)]
        public string StoreName { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public string Notes { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
    }
}
