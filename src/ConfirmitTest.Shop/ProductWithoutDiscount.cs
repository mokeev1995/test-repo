using System;
using ConfirmitTest.Shop.Common;

namespace ConfirmitTest.Shop
{
    public class ProductWithoutDiscount : CartItemInheritorBase
    {
        public ProductWithoutDiscount(ICartItem cartItem, uint discountValue)
            : base(cartItem)
        {
            throw new NotImplementedException();
        }

        public override decimal GetCost()
        {
            throw new NotImplementedException();
        }

        public override ICartItem GetState()
        {
            throw new NotImplementedException();
        }
    }
}