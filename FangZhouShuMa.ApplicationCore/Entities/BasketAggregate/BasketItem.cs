using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Entities.BasketAggregate
{
    public class BasketItem : BaseEntity
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public DateTime UpdateDateUtc { get; set; }
    }
}
