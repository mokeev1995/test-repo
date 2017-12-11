using ConfirmitTest.Core;
using ConfirmitTest.Core.Repositories;
using ConfirmitTest.Entities;

namespace ConfirmitTest.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        
    }

    public class ProductRepository : ListBasedRepository<Product>, IProductRepository
    {
        public ProductRepository()
        {
            Storage.AddRange(new []
            {
                new Product{ Name = "Intel Core i7 8700K", Cost = 350, VendorCode = 0012}, 
                new Product{ Name = "Intel Core i5 8600K", Cost = 320, VendorCode = 1011}, 
                new Product{ Name = "Intel Core i7 7700K", Cost = 340, VendorCode = 0010}, 
                new Product{ Name = "Intel Core i5 7600K", Cost = 340, VendorCode = 0002}, 
                new Product{ Name = "Intel Core i3 7300", Cost = 340, VendorCode = 0001}, 
            });
        }
    }
}
