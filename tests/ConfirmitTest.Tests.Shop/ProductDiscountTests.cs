using ConfirmitTest.Shop;
using ConfirmitTest.Tests.SharedClasses;
using Xunit;

namespace ConfirmitTest.Tests.Shop
{
    public class ProductDiscountTests
    {
        [Fact]
        public void DiscountWorks()
        {
            var cart = CommonInstansesCreator.GetCart();
            var productRepository = CommonInstansesCreator.GetProductRepo();
            var product = productRepository.FirstOrDefault();

            var item = new CartItem {Count = 2, Product = product};

            cart.AddProduct(new ProductDiscount(item, 50));

            Assert.Equal(product.Cost, cart.GetCost());
        }
    }
}