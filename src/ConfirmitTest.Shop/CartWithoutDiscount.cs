using ConfirmitTest.Shop.Common;

namespace ConfirmitTest.Shop
{
    public class CartWithoutDiscount : CartInheritorBase
    {
        private readonly uint _discountValue;

        public CartWithoutDiscount(ICart cartWithDiscount, uint discountValue)
            : base(cartWithDiscount)
        {
            _discountValue = discountValue;
        }

        public override decimal GetCost()
        {
            const decimal maxPersentageValue = 100;
            return maxPersentageValue * Cart.GetCost() / (maxPersentageValue - _discountValue);
        }

        public override ICart GetState()
        {
            return new CartWithoutDiscount(Cart, _discountValue);
        }
    }
}