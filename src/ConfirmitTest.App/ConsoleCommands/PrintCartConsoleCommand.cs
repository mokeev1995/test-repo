using System.Linq;
using ConfirmitTest.Core;
using ConfirmitTest.Shop;

namespace ConfirmitTest.App.ConsoleCommands
{
    public class PrintCartConsoleCommand : IConsoleCommand
    {
        private readonly IOutputReciever _outputReciever;
        private readonly ICartService _cartService;
        private readonly IOutputListManager<ICartItem> _listManager;

        public PrintCartConsoleCommand(
            IOutputReciever outputReciever,
            ICartService cartService,
            IOutputListManager<ICartItem> listManager
        )
        {
            _outputReciever = outputReciever;
            _cartService = cartService;
            _listManager = listManager;
        }

        public void Execute()
        {
            _outputReciever.ClearScreen();
            
            PrintCartItems();

            _outputReciever.WriteLine(new string('-', 20));
            _outputReciever.WriteLine($"Total: ${_cartService.GetTotalPrice()}");

            _outputReciever.GetStringResponse();
        }

        private void PrintCartItems()
        {
            var items = _cartService.GetCartItems();

            _listManager.SetItems(items);
            _listManager.SetItemToString(item =>
                $"Name: {item.Product.Name}, Price: ${item.Product.Cost}, Count: {item.Count}, Cost: ${item.GetCost()}"
            );
            _listManager.PrintItems();
        }

        public string Title { get; } = "Print check.";
    }
}