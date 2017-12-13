using ConfirmitTest.Core;
using ConfirmitTest.Repositories;
using ConfirmitTest.Shop;

namespace ConfirmitTest.Tests.SharedClasses
{
    public static class CommonInstansesCreator
    {
        public static IProductRepository GetProductRepo()
        {
            return new ProductRepository();
        }

        public static ICartService GetCartService(IHistoryManager<ICart> historyManager = null)
        {
            return new CartService(historyManager ?? GetHistoryManager<ICart>());
        }

        public static IHistoryManager<T> GetHistoryManager<T>()
            where T : class
        {
            return new HistoryManager<T>();
        }
        public static TestOutputReciever GetOutputReciever()
        {
            return new TestOutputReciever();
        }

        public static IOutputListManager<T> GetOutputListManager<T>(IOutputReciever reciever = null)
            where T : class
        {
            return new OutputListManager<T>(reciever ?? GetOutputReciever());
        }

        public static ICart GetCart()
        {
            return new Cart();
        }
    }
}