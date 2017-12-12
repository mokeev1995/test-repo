using ConfirmitTest.Core;
using ConfirmitTest.Core.Repositories;
using ConfirmitTest.Entities;

namespace ConfirmitTest.Repositories
{
    public interface ICartCouponRepository : IRepository<CartCoupon>
    {
        
    }
    
    public class CartCouponRepository : ListBasedRepository<CartCoupon>, ICartCouponRepository
    {
        public CartCouponRepository()
        {
            Storage.AddRange(new[]
            {
                new CartCoupon {Key = "test-cart1", Value = 35},
                new CartCoupon {Key = "test-cart2", Value = 15},
                new CartCoupon {Key = "test-cart3", Value = 20},
                new CartCoupon {Key = "test-cart4", Value = 10},
            });
        }
    }
}