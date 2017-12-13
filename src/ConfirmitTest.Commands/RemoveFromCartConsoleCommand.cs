using ConfirmitTest.Core;
using ConfirmitTest.Core.Extensions;
using ConfirmitTest.Shop;

namespace ConfirmitTest.Commands
{
    public class RemoveFromCartConsoleCommand : IConsoleCommand
    {
        private readonly IOutputReciever _outputReciever;
        private readonly ICartService _cartService;
        private readonly IOutputListManager<ICartItem> _listManager;

        public RemoveFromCartConsoleCommand(
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

            _outputReciever.WriteLine("Select item from cart to remove:");

            _listManager.SetItems(_cartService.GetCartItems());
            _listManager.SetItemToString(item => $"{item.Product.Name}, In cart: {item.Count}");
            _listManager.PrintItems();

            var selectedProduct = _listManager.GetSelectedItem();
            if (selectedProduct.IsNull())
            {
                _outputReciever.WriteError("You didn't select anything. Try again.");
                return;
            }
            _cartService.RemoveProduct(selectedProduct.Product);
            _outputReciever.WriteWarn($"Product '{selectedProduct.Product.Name}' successfully removed.");
        }

        public string Title { get; } = "Remove from cart.";
    }
}