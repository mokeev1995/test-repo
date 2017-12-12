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
        public ProductCouponRepository(IProductRepository productRepository)
        {
            var products = productRepository.GetAllList();
            Storage.AddRange(new[]
            {
                new ProductCoupon {Key = "test1", Value = 30, Product = products[1]},
                new ProductCoupon {Key = "test2", Value = 10, Product = products[2]},
                new ProductCoupon {Key = "test3", Value = 15, Product = products[3]},
                new ProductCoupon {Key = "test4", Value = 5, Product = products[4]},
            });
        }
    }
}