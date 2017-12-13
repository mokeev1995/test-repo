using ConfirmitTest.Shop.Common;

namespace ConfirmitTest.Shop
{
    public class ProductDiscount : CartItemInheritorBase
    {
        private readonly uint _discountValue;

        public ProductDiscount(ICartItem cartItem, uint discountValue)
            : base(cartItem)
        {
            _discountValue = discountValue;
        }

        public override decimal GetCost()
        {
            var cost = CartItem.GetCost();
            return cost - GetDiscountValue(cost);
        }
        
        private decimal GetDiscountValue(decimal currentCost)
        {
            const int maxPersentageValue = 100;

            return _discountValue * currentCost / maxPersentageValue;
        }

        public override ICartItem GetState()
        {
            return new ProductDiscount(CartItem, _discountValue);
        }
    }
}