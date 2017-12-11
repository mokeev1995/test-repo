using System;
using System.Collections.Generic;
using System.Linq;
using ConfirmitTest.Entities;

namespace ConfirmitTest.Shop
{
    public class Cart : ICart
    {
        private readonly List<ICartItem> _productsInCart;

        public Cart()
            : this(new List<ICartItem>())
        {
        }

        private Cart(IEnumerable<ICartItem> productsInCart)
        {
            _productsInCart = productsInCart.ToList();
        }

        public IEnumerable<ICartItem> ProductsInCart => _productsInCart;

        public void ReplaceProduct(ICartItem cartItem)
        {
            var productFromCart = GetCartItem(cartItem.Product);
            
            var itemIndex = _productsInCart.IndexOf(productFromCart);

            _productsInCart[itemIndex] = cartItem;
        }

        public void AddProduct(ICartItem cartItem)
        {
            var foundItem = GetItemOrNull(cartItem.Product);

            if (foundItem == null)
            {
                _productsInCart.Add(cartItem);
                return;
            }

            foundItem.Count += cartItem.Count;
        }

        public void RemoveProduct(ICartItem cartItem)
        {
            _productsInCart.RemoveAll(item => item.Product == cartItem.Product);
        }

        public ICartItem GetCartItem(Product product)
        {
            var foundItem = GetItemOrNull(product);

            if (foundItem == null)
                throw new IndexOutOfRangeException("Product was not found in cart!");

            return foundItem;
        }

        public ICart GetState()
        {
            return new Cart(_productsInCart.Select(item => item.GetState()));
        }

        public decimal GetCost()
        {
            return _productsInCart.Sum(item => item.GetCost());
        }

        private ICartItem GetItemOrNull(Product product)
        {
            return _productsInCart.FirstOrDefault(item => item.Product == product);
        }
    }
}