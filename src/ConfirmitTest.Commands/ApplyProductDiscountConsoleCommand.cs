using ConfirmitTest.Core;
using ConfirmitTest.Core.Extensions;
using ConfirmitTest.Entities;
using ConfirmitTest.Repositories;
using ConfirmitTest.Shop;

namespace ConfirmitTest.Commands
{
    public class ApplyProductDiscountConsoleCommand : IConsoleCommand
    {
        private readonly IOutputReciever _outputReciever;
        private readonly IOutputListManager<ICartItem> _listManager;
        private readonly ICartService _cartService;
        private readonly IProductCouponRepository _couponRepository;

        public ApplyProductDiscountConsoleCommand(
            IOutputReciever outputReciever,
            IOutputListManager<ICartItem> listManager,
            ICartService cartService,
            IProductCouponRepository couponRepository
        )
        {
            _outputReciever = outputReciever;
            _listManager = listManager;
            _cartService = cartService;
            _couponRepository = couponRepository;
        }

        public void Execute()
        {
            _outputReciever.ClearScreen();
            _outputReciever.WriteLine("Select product from cart:");
            
            var items = _cartService.GetCartItems();
            
            _listManager.SetItems(items);
            _listManager.SetItemToString(item => $"{item.Product.Name}");
            _listManager.PrintItems();
            
            var selectedProduct = _listManager.GetSelectedItem();
            if (selectedProduct.IsNull())
            {
                _outputReciever.WriteError("You didn't select product!");
                return;
            }

            _outputReciever.Write("Enter your key: ");
            
            var key = GetCouponKey();

            if (key.IsNullOrWhiteSpace())
            {
                _outputReciever.WriteError($"Entered key '{key}' does not conform our rules.");
                return;
            }
            
            var coupon = GetCoupon(key);

            if (coupon.IsNull())
            {
                _outputReciever.WriteError($"Coupon with key '{key}' does not exists.");
                return;
            }

            if (coupon.Product != selectedProduct.Product)
            {
                _outputReciever.WriteError($"Coupon with key '{key}' does not applies to that product.");
                return;
            }
            
            _cartService.AddProductDiscount(selectedProduct.Product, coupon.Value);
            
            _outputReciever.WriteInfo($"Coupon added. Discount to {selectedProduct.Product.Name} is {coupon.Value}%");
        }

        private ProductCoupon GetCoupon(string key)
        {
            return _couponRepository.FirstOrDefault(coupon => coupon.Key == key);
        }

        private string GetCouponKey()
        {
            var key = _outputReciever.GetStringResponse();
            
            return key.IsNullOrWhiteSpace() 
                ? null 
                : key;
        }

        public string Title { get; } = "Add product discount.";
    }
}