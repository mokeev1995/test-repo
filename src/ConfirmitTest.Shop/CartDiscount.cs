using ConfirmitTest.Shop.Common;

namespace ConfirmitTest.Shop
{
    public class CartDiscount : CartInheritorBase
    {
        private readonly uint _discountPersentage;

        public CartDiscount(ICart currentCart, uint discountPersentage)
            : base(currentCart)
        {
            _discountPersentage = discountPersentage;
        }

        public override decimal GetCost()
        {
            var cost = Cart.GetCost();
            return cost - GetDiscountValue(cost);
        }

        private decimal GetDiscountValue(decimal currentCost)
        {
            const int maxPersentageValue = 100;

            return _discountPersentage * currentCost / maxPersentageValue;
        }

        public override ICart GetState()
        {
            return new CartDiscount(Cart, _discountPersentage);
        }
    }
}