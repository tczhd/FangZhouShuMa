using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.GuardClauses;
using FangZhouShuMa.ApplicationCore.Entities.BasketAggregate;
using FangZhouShuMa.ApplicationCore.Exceptions;

namespace FArdalis.GuardClauses
{
    public static class BasketGuards
    {
        public static void NullBasket(this IGuardClause guardClause, int basketId, Basket basket)
        {
            if (basket == null)
                throw new BasketNotFoundException(basketId);
        }
    }
}
