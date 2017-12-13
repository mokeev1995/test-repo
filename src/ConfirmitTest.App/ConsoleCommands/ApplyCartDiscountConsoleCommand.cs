using ConfirmitTest.Core;
using ConfirmitTest.Core.Extensions;
using ConfirmitTest.Entities;
using ConfirmitTest.Repositories;
using ConfirmitTest.Shop;

namespace ConfirmitTest.App.ConsoleCommands
{
    public class ApplyCartDiscountConsoleCommand : IConsoleCommand
    {
        private readonly IOutputReciever _outputReciever;
        private readonly ICartService _cartService;
        private readonly ICartCouponRepository _cartCouponRepository;

        public ApplyCartDiscountConsoleCommand(
            IOutputReciever outputReciever, 
            ICartService cartService,
            ICartCouponRepository cartCouponRepository
        )
        {
            _outputReciever = outputReciever;
            _cartService = cartService;
            _cartCouponRepository = cartCouponRepository;
        }

        public void Execute()
        {
            _outputReciever.ClearScreen();
            _outputReciever.Write("Enter your key: ");
            
            var key = _outputReciever.GetStringResponse();

            if (key.IsNullOrWhiteSpace())
            {
                _outputReciever.WriteError($"Entered key '{key}' does not conform our rules.");
                return;
            }
            
            var coupon = GetCouponByKey(key);
            
            if (coupon.IsNull())
            {
                _outputReciever.WriteError($"Coupon with key '{key}' does not exists.");
                return;
            }
            
            _cartService.AddCartDiscount(coupon.Value);
            _outputReciever.WriteInfo($"Coupon added. Discount to cart is {coupon.Value}%");
        }

        private CartCoupon GetCouponByKey(string key)
        {
            return _cartCouponRepository.FirstOrDefault(coupon => coupon.Key == key);
        }

        public string Title { get; } = "Add cart discount.";
    }
}