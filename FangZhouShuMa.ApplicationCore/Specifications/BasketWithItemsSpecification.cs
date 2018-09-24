﻿using System;
using System.Collections.Generic;
using System.Text;
using FangZhouShuMa.ApplicationCore.Entities.BasketAggregate;

namespace FangZhouShuMa.ApplicationCore.Specifications
{
    public class BasketWithItemsSpecification : BaseSpecification<Basket>
    {
        public BasketWithItemsSpecification(int basketId)
            : base(b => b.Id == basketId)
        {
            AddInclude(b => b.Items);
        }
        public BasketWithItemsSpecification(string buyerId)
            : base(b => b.BuyerId == buyerId)
        {
            AddInclude(b => b.Items);
            AddInclude($"{nameof(Basket.Items)}.{nameof(BasketItem.ItemDetails)}");
        }
    }
}
