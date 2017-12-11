using System.Linq;
using ConfirmitTest.Core;
using ConfirmitTest.Entities;
using ConfirmitTest.Repositories;
using ConfirmitTest.Shop;

namespace ConfirmitTest.App.ConsoleCommands
{
    public class AddToCartConsoleCommand : IConsoleCommand
    {
        private readonly IProductRepository _productRepository;
        private readonly IOutputReciever _outputReciever;
        private readonly ICartService _cartService;

        public AddToCartConsoleCommand(
            IProductRepository productRepository, 
            IOutputReciever outputReciever, 
            ICartService cartService
        )
        {
            _productRepository = productRepository;
            _outputReciever = outputReciever;
            _cartService = cartService;
        }

        public void Execute()
        {
            _outputReciever.ClearScreen();
            
            ShowProducts();
            var selected = GetSelectedProduct();
            if (selected == null)
            {
                _outputReciever.WriteError("Wrong index of product. Try to choose other.");
                return;
            }

            _cartService.AddProduct(selected);
            _outputReciever.WriteInfo($"Product '{selected.Name}' successfully added to your cart!");
        }

        private Product GetSelectedProduct()
        {
            var products = _productRepository.GetAllList();
            var prod = _outputReciever.GetIntResponse();

            if (prod >= 0 && prod <= products.Count - 1)
                return products[prod];

            return null;
        }

        private void ShowProducts()
        {
            _outputReciever.WriteLine("Choose product:");
            var productsDescription = _productRepository.GetAllList()
                .Select(product => $"{product.Name} | ${product.Cost}");
            _outputReciever.WriteMenuItems(productsDescription);
        }

        public string Title { get; } = "Add to cart.";
    }
}