using ConfirmitTest.Shop;
using ConfirmitTest.Tests.SharedClasses;
using Xunit;

namespace ConfirmitTest.Tests.Shop
{
    public class CartDiscountTests
    {
        [Fact]
        public void DiscountWorks()
        {
            var cart = CommonInstansesCreator.GetCart();
            var productRepository = CommonInstansesCreator.GetProductRepo();
            var product = productRepository.FirstOrDefault();

            cart.AddProduct(new CartItem {Count = 2, Product = product});

            var discount = new CartDiscount(cart, 50);

            Assert.Equal(product.Cost, discount.GetCost());
        }

        [Fact]
        public void DiscountForEmptyCart()
        {
            var cart = CommonInstansesCreator.GetCart();

            var discount = new CartDiscount(cart, 50);

            Assert.Equal(0, discount.GetCost());
        }
    }
}