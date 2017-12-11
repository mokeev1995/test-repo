using ConfirmitTest.Entities;

namespace ConfirmitTest.Shop
{
    public class CartItem : ICartItem
    {
        public Product Product { get; set; }
        public uint Count { get; set; }

        public decimal GetCost()
        {
            return Count * Product.Cost;
        }

        public ICartItem GetState()
        {
            return new CartItem
            {
                Product = Product,
                Count = Count
            };
        }
    }
}