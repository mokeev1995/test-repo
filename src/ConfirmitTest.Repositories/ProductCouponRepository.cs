using ConfirmitTest.Core;
using ConfirmitTest.Core.Repositories;
using ConfirmitTest.Entities;

namespace ConfirmitTest.Repositories
{
    public interface IProductCouponRepository : IRepository<ProductCoupon>
    {
        
    }
    
    public class ProductCouponRepository : ListBasedRepository<ProductCoupon>, IProductCouponRepository
    {
        public ProductCouponRepository()
        {
            Storage.AddRange(new[]
            {
                new ProductCoupon {Key = "test1", Value = 30},
                new ProductCoupon {Key = "test2", Value = 10},
                new ProductCoupon {Key = "test3", Value = 15},
                new ProductCoupon {Key = "test4", Value = 5},
            });
        }
    }
}