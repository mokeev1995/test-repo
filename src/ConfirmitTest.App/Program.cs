using ConfirmitTest.Commands;
using ConfirmitTest.Core;
using ConfirmitTest.Repositories;
using ConfirmitTest.Shop;
using Microsoft.Extensions.DependencyInjection;

namespace ConfirmitTest.App
{
    internal static class Program
    {
        private static void Main()
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            var serviceProvider = services.BuildServiceProvider();

            var menu = serviceProvider.GetRequiredService<ConsoleMenu>();

            menu.Start();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ConsoleMenu>()
                .AddTransient(typeof(IOutputListManager<>), typeof(OutputListManager<>))
                .AddSingleton(typeof(IHistoryManager<>), typeof(HistoryManager<>));

            services
                .AddDefaultConsoleCommand<DefaultConsoleCommand>()
                .AddConsoleCommands();

            services.AddRepositories();

            services.AddCartService<CartService>();

            services.AddSingleton<IOutputReciever, ConsoleReciever>();
        }
    }
}