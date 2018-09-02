using FangZhouShuMa.ApplicationCore.Entities.CustomerAggregate;
using FangZhouShuMa.ApplicationCore.Entities.UserAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FangZhouShuMa.ApplicationCore.Entities.OrderAggreagte
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
            ShippingInfos = new HashSet<ShippingInfo>();
            BillingInfos = new HashSet<BillingInfo>();
        }

        public DateTime OrderDate { get; set; }

        public bool Deleted { get; set; }

        public int CreatedById { get; set; }

        public int? EditedById { get; set; }

        public DateTime? ConfirmationDate { get; set; }

        [StringLength(1000)]
        public string CustomerNotes { get; set; }

        public string InternalNotes { get; set; }

        public decimal OrderDiscount { get; set; }

        public int CustomerId { get; set; }

        public int OrderStatus { get; set; }

        public int ShippingInfoId { get; set; }

        public int BillingInfoId { get; set; }

        public decimal ShippingSubTotal { get; set; }

        public decimal ShippingDiscount { get; set; }

        public decimal ShippingTaxRate { get; set; }

        public DateTime LastUpdateDateUTC { get; set; }

        public decimal? SubTotal { get; set; }

        public decimal? TaxTotal { get; set; }
        public decimal? Total { get; set; }
        public decimal? AmountPaid { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual SiteUser SiteUserCreated { get; set; }
        public virtual SiteUser SiteUserEdited { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<ShippingInfo> ShippingInfos { get; set; }
        public virtual ICollection<BillingInfo> BillingInfos { get; set; }
    }
}
