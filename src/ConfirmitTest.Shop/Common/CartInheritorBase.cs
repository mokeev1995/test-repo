using System.Collections.Generic;
using ConfirmitTest.Entities;

namespace ConfirmitTest.Shop.Common
{
    public abstract class CartInheritorBase : ICart
    {
        protected CartInheritorBase(ICart cart)
        {
            Cart = cart;
        }

        protected ICart Cart { get; }
        
        public virtual void ReplaceProduct(ICartItem cartItem)
        {
            Cart.ReplaceProduct(cartItem);
        }

        public virtual void AddProduct(ICartItem cartItem)
        {
            Cart.AddProduct(cartItem);
        }

        public virtual void RemoveProduct(ICartItem cartItem)
        {
            Cart.RemoveProduct(cartItem);
        }

        public virtual IEnumerable<ICartItem> ProductsInCart => Cart.ProductsInCart;

        public virtual ICartItem GetCartItem(Product product)
        {
            return Cart.GetCartItem(product);
        }

        public abstract decimal GetCost();
        public abstract ICart GetState();
    }
}