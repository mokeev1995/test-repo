using ConfirmitTest.Core;
using ConfirmitTest.Core.Extensions;
using ConfirmitTest.Entities;
using ConfirmitTest.Repositories;
using ConfirmitTest.Shop;

namespace ConfirmitTest.Commands
{
    public class AddToCartConsoleCommand : IConsoleCommand
    {
        private readonly IProductRepository _productRepository;
        private readonly IOutputReciever _outputReciever;
        private readonly ICartService _cartService;
        private readonly IOutputListManager<Product> _listManager;

        public AddToCartConsoleCommand(
            IProductRepository productRepository, 
            IOutputReciever outputReciever, 
            ICartService cartService,
            IOutputListManager<Product> listManager
        )
        {
            _productRepository = productRepository;
            _outputReciever = outputReciever;
            _cartService = cartService;
            _listManager = listManager;
        }

        public void Execute()
        {
            _outputReciever.ClearScreen();
            
            ShowProducts();
            var selected = GetSelectedProduct();
            if (selected.IsNull())
            {
                _outputReciever.WriteError("Wrong index of product. Try to choose other.");
                return;
            }

            _cartService.AddProduct(selected);
            _outputReciever.WriteInfo($"Product '{selected.Name}' successfully added to your cart!");
        }

        private Product GetSelectedProduct()
        {
            return _listManager.GetSelectedItem();
        }

        private void ShowProducts()
        {
            _outputReciever.WriteLine("Choose product:");
            
            _listManager.SetItemToString(product => $"{product.Name} | ${product.Cost}");
            _listManager.SetItems(_productRepository.GetAllList());
            _listManager.PrintItems();
        }

        public string Title { get; } = "Add to cart.";
    }
}