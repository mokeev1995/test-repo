using System;
using ConfirmitTest.Core;
using ConfirmitTest.Core.Extensions;
using ConfirmitTest.Shop;

namespace ConfirmitTest.App.ConsoleCommands
{
    public class DecreaseProductCount : IConsoleCommand
    {
        private readonly IOutputReciever _outputReciever;
        private readonly ICartService _cartService;
        private readonly IOutputListManager<ICartItem> _listManager;

        public DecreaseProductCount(
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
            _outputReciever.WriteLine("Select product:\n");

            _listManager.SetItems(_cartService.GetCartItems());
            _listManager.SetItemToString(item => $"{item.Product.Name}");
            _listManager.PrintItems();

            _outputReciever.Write("Your choise: ");
            var selectedItem = _listManager.GetSelectedItem();

            if (selectedItem.IsNull())
            {
                _outputReciever.WriteError("You didn't select anything. Try again.");
                return;
            }

            _outputReciever.Write("\nHow much products do we need to remove from cart? [1] ");
            var count = _outputReciever.GetIntResponse() ?? 1;

            if (count < 1)
            {
                _outputReciever.WriteError("Can't remove less than 1 product.");
                return;
            }

            _cartService.AddProduct(selectedItem.Product, Convert.ToUInt32(count));

            _outputReciever.WriteInfo($"Added {count} product(-s).");
        }

        public string Title { get; } = "Decrease product count.";
    }
}