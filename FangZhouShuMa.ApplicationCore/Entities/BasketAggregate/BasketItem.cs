using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FangZhouShuMa.ApplicationCore.Entities.BasketAggregate
{
    public class BasketItem : BaseEntity
    {
        private readonly List<BasketItemDetail> _itemDetails = new List<BasketItemDetail>();
        public ICollection<BasketItemDetail> ItemDetails => _itemDetails;
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public DateTime UpdateDateUtc { get; set; }
        public void AddItemDetail(List<BasketItemDetail> itemDetails)
        {
            _itemDetails.AddRange(itemDetails);
        }
    }
}
