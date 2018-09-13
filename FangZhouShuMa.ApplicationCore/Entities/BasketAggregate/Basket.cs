using System;
using FangZhouShuMa.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace FangZhouShuMa.ApplicationCore.Entities.BasketAggregate
{
    public class Basket : BaseEntity, IAggregateRoot
    {
        public string BuyerId { get; set; }
        private readonly List<BasketItem> _items = new List<BasketItem>();
        public ICollection<BasketItem> Items => _items;

        public void AddItem(int productId, decimal unitPrice, List<BasketItemDetail> itemDetails, decimal quantity = 1)
        {
            var item = Items.SingleOrDefault(p => p.ProductId == productId);
            if (item != null)
            {
                Items.Remove(item);
            }

            var newItem = new BasketItem()
            {
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = unitPrice,
                UpdateDateUtc = DateTime.UtcNow,
            };
            _items.Add(newItem);

            newItem.AddItemDetail(itemDetails);

            //if (Items.All(i => i.ProductId != productId))
            //{
            //    var newItem = new BasketItem()
            //    {
            //        ProductId = productId,
            //        Quantity = quantity,
            //        UnitPrice = unitPrice,
            //        UpdateDateUtc = DateTime.UtcNow,
            //    };
            //    _items.Add(newItem);

            //    newItem.AddItemDetail(itemDetails);
            //    return;
            //}

            //var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            //existingItem.Quantity += quantity;
        }
    }
}
