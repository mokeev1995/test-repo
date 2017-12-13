using ConfirmitTest.Core;
using ConfirmitTest.Repositories;
using ConfirmitTest.Shop;
using ConfirmitTest.Tests.SharedClasses;

namespace ConfirmitTest.Tests.Commands
{
    public class CommandTestBase
    {
        protected IProductRepository GetProductRepo()
        {
            return new ProductRepository();
        }

        protected TestOutputReciever GetOutputReciever()
        {
            return new TestOutputReciever();
        }

        protected IHistoryManager<T> GetHistoryManager<T>()
            where T : class
        {
            return new HistoryManager<T>();
        }

        protected IOutputListManager<T> GetOutputListManager<T>(IOutputReciever reciever = null)
            where T : class
        {
            return new OutputListManager<T>(reciever ?? GetOutputReciever());
        }

        protected ICartService GetCartService(IHistoryManager<ICart> historyManager = null)
        {
            return new CartService(historyManager ?? GetHistoryManager<ICart>());
        }
    }
}