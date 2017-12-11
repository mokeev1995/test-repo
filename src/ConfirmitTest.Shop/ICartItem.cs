using ConfirmitTest.Core;
using ConfirmitTest.Entities;

namespace ConfirmitTest.Shop
{
    public interface ICartItem : IPriceCalculator, IStorable<ICartItem>
    {
        Product Product { get; set; }
        uint Count { get; set; }
    }
}