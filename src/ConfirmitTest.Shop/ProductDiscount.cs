using System;
using ConfirmitTest.Shop.Common;

namespace ConfirmitTest.Shop
{
    public class ProductDiscount : CartItemInheritorBase
    {
        public ProductDiscount(ICartItem cartItem, uint discountValue)
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