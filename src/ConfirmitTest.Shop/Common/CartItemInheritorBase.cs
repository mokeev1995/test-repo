using ConfirmitTest.Entities;

namespace ConfirmitTest.Shop.Common
{
    public abstract class CartItemInheritorBase : ICartItem
    {
        protected readonly ICartItem CartItem;

        protected CartItemInheritorBase(ICartItem cartItem)
        {
            CartItem = cartItem;
        }

        public Product Product
        {
            get => CartItem.Product;
            set => CartItem.Product = value;
        }

        public uint Count
        {
            get => CartItem.Count;
            set => CartItem.Count = value;
        }

        public abstract decimal GetCost();
        public abstract ICartItem GetState();
    }
}