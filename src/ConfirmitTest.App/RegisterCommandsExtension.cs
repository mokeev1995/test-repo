using ConfirmitTest.App.ConsoleCommands;
using ConfirmitTest.Core;
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
                .AddSingleton<IConsoleCommand, AddCartDiscountConsoleCommand>()
                .AddSingleton<IConsoleCommand, AddProductDiscountConsoleCommand>()
                .AddSingleton<IConsoleCommand, PrintCartConsoleCommand>()
                .AddTransient<IConsoleCommand, ExitConsoleCommand>();
        }
    }
}