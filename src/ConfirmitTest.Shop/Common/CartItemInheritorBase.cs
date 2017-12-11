using ConfirmitTest.Entities;

namespace ConfirmitTest.Shop.Common
{
    public abstract class CartItemInheritorBase : ICartItem
    {
        private readonly ICartItem _cartItem;

        protected CartItemInheritorBase(ICartItem cartItem)
        {
            _cartItem = cartItem;
        }

        public Product Product
        {
            get => _cartItem.Product;
            set => _cartItem.Product = value;
        }

        public uint Count
        {
            get => _cartItem.Count;
            set => _cartItem.Count = value;
        }

        public abstract decimal GetCost();
        public abstract ICartItem GetState();
    }
}