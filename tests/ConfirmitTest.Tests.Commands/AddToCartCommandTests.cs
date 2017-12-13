using System;
using System.Linq;
using ConfirmitTest.Commands;
using ConfirmitTest.Core;
using ConfirmitTest.Entities;
using ConfirmitTest.Repositories;
using ConfirmitTest.Shop;
using ConfirmitTest.Tests.SharedClasses;
using Xunit;

namespace ConfirmitTest.Tests.Commands
{
    public class AddToCartCommandTests
    {
        [Fact]
        public void CommandTitleSet()
        {
            var cmd = GetCommand(CommonInstansesCreator.GetOutputReciever(), CommonInstansesCreator.GetOutputReciever());

            Assert.Equal("Add to cart.", cmd.Title);
        }

        [Fact]
        public void ProductJustAddedToCart()
        {
            var commandReciever = CommonInstansesCreator.GetOutputReciever();
            var listMgrReciever = CommonInstansesCreator.GetOutputReciever();

            listMgrReciever.GetIntResponses.Enqueue(0);

            var productRepository = CommonInstansesCreator.GetProductRepo();
            var cartService = CommonInstansesCreator.GetCartService();

            var command = GetCommand(commandReciever, listMgrReciever, productRepository, cartService);
            command.Execute();

            var item = productRepository.FirstOrDefault() ?? throw new NullReferenceException();

            Assert.Equal(new []{ item }, cartService.GetCartItems().Select(cartItem => cartItem.Product));
            Assert.Equal(new []{ 1U }, cartService.GetCartItems().Select(cartItem => cartItem.Count));
        }

        [Fact]
        public void ProductJustAddedToCart_WrongItemSelection()
        {
            var commandReciever = CommonInstansesCreator.GetOutputReciever();
            var listMgrReciever = CommonInstansesCreator.GetOutputReciever();

            listMgrReciever.GetIntResponses.Enqueue(-1);
            
            var command = GetCommand(commandReciever, listMgrReciever);
            command.Execute();
            
            Assert.Equal(new []{ "Wrong index of product. Try to choose other." }, commandReciever.ErrorWrites.ToArray());
        }

        private IConsoleCommand GetCommand(
            IOutputReciever commandOutputReciever, 
            IOutputReciever listManagerOutputReciever, 
            IProductRepository productRepository = null,
            ICartService cartService = null
        )
        {
            return new AddToCartConsoleCommand(
                productRepository ?? CommonInstansesCreator.GetProductRepo(),
                commandOutputReciever,
                cartService ?? CommonInstansesCreator.GetCartService(),
                CommonInstansesCreator.GetOutputListManager<Product>(listManagerOutputReciever)
            );
        }
    }
}
