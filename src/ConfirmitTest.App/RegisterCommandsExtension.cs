using System.Linq;
using ConfirmitTest.App.ConsoleCommands;
using ConfirmitTest.Core;
using ConfirmitTest.Shop;
using Microsoft.Extensions.DependencyInjection;

namespace ConfirmitTest.App
{
    public static class RegisterCommandsExtension
    {
        public static IServiceCollection AddDefaultConsoleCommand<T>(this IServiceCollection services)
            where T : class, IDefaultConsoleCommand
        {
            return services.AddSingleton<IDefaultConsoleCommand, T>();
        }

        public static IServiceCollection AddConsoleCommands(this IServiceCollection services)
        {
            return services
                .AddSingleton<IConsoleCommand, AddToCartConsoleCommand>()
                .AddSingleton<IConsoleCommand, RemoveFromCartConsoleCommand>()
                .AddSingleton<IConsoleCommand, PrintCartConsoleCommand>()
                .AddTransient<IConsoleCommand, ExitConsoleCommand>();
        }
    }

    public class PrintCartConsoleCommand : IConsoleCommand
    {
        private readonly IOutputReciever _outputReciever;
        private readonly ICartService _cartService;

        public PrintCartConsoleCommand(IOutputReciever outputReciever, ICartService cartService)
        {
            _outputReciever = outputReciever;
            _cartService = cartService;
        }

        public void Execute()
        {
            _outputReciever.ClearScreen();

            var items = _cartService.GetCartItems()
                .Select(item =>
                    $"Name: {item.Product.Name}, Price: ${item.Product.Cost}, Count: {item.Count}, Cost: ${item.GetCost()}"
                );
            _outputReciever.WriteMenuItems(items);

            _outputReciever.WriteLine(new string('-', 20));
            _outputReciever.WriteLine($"Total: ${_cartService.GetTotalPrice()}");

            _outputReciever.GetStringResponse();
        }

        public string Title { get; } = "Print check.";
    }
}