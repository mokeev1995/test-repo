using System.Collections.Generic;
using ConfirmitTest.Core;
using ConfirmitTest.Entities;

namespace ConfirmitTest.Shop
{
    public interface ICartService
    {
        void AddProduct(Product product, uint count = 1);
        void AddCartDiscount(uint discountValue);
        void AddProductDiscount(Product product, uint discountValue);

        void RemoveProduct(Product product);

        void Undo(uint count = 1);
        void Redo(uint count = 1);

        IEnumerable<ICartItem> GetCartItems();
        decimal GetTotalPrice();
    }

    public class CartService : ICartService
    {
        private readonly IHistoryManager<ICart> _cartHistory;

        public CartService(IHistoryManager<ICart> cartHistory)
        {
            _cartHistory = cartHistory;
            _cartHistory.SaveNextState(new Cart());
        }

        public void AddProduct(Product product, uint count = 1)
        {
            var current = GetCurrentCartState();
            current.AddProduct(new CartItem {Product = product, Count = count});
            _cartHistory.SaveNextState(current);
        }

        public void AddCartDiscount(uint discountValue)
        {
            var current = GetCurrentCartState();
            var cartWithDiscount = new CartDiscount(current, discountValue);
            _cartHistory.SaveNextState(cartWithDiscount);
        }

        public void AddProductDiscount(Product product, uint discountValue)
        {
            var current = GetCurrentCartState();
            var item = current.GetCartItem(product);
            current.ReplaceProduct(new ProductDiscount(item, discountValue));
            _cartHistory.SaveNextState(current);
        }

        public void RemoveProduct(Product product)
        {
            var current = GetCurrentCartState();
            var item = current.GetCartItem(product);
            current.RemoveProduct(item);
            _cartHistory.SaveNextState(current);
        }

        public void Undo(uint count = 1)
        {
            _cartHistory.Undo(count);
        }

        public void Redo(uint count = 1)
        {
            _cartHistory.Redo(count);
        }

        public IEnumerable<ICartItem> GetCartItems()
        {
            return GetCurrentCartState().ProductsInCart;
        }

        public decimal GetTotalPrice()
        {
            return GetCurrentCartState().GetCost();
        }

        private ICart GetCurrentCartState() => _cartHistory.GetCurrentItem().GetState();
    }
}