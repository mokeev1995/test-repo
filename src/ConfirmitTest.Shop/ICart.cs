using System.Collections.Generic;
using ConfirmitTest.Core;
using ConfirmitTest.Entities;

namespace ConfirmitTest.Shop
{
    public interface ICart : IPriceCalculator, IStorable<ICart>
    {
        IEnumerable<ICartItem> ProductsInCart { get; }

        /// <exception cref="System.IndexOutOfRangeException">Product was not found in cart!</exception>
        void ReplaceProduct(ICartItem cartItem);

        void AddProduct(ICartItem cartItem);
        void RemoveProduct(ICartItem cartItem);

        /// <exception cref="System.IndexOutOfRangeException">Product was not found in cart!</exception>
        ICartItem GetCartItem(Product product);
    }
}