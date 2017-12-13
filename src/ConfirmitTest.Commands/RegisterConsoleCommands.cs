using ConfirmitTest.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ConfirmitTest.Commands
{
    public static class RegisterConsoleCommands
    {
        public static IServiceCollection AddConsoleCommands(this IServiceCollection services)
        {
            return services
                .AddSingleton<IConsoleCommand, AddToCartConsoleCommand>()
                .AddSingleton<IConsoleCommand, RemoveFromCartConsoleCommand>()
                .AddSingleton<IConsoleCommand, IncreaseProductCount>()
                .AddSingleton<IConsoleCommand, DecreaseProductCount>()
                .AddSingleton<IConsoleCommand, ApplyCartDiscountConsoleCommand>()
                .AddSingleton<IConsoleCommand, ApplyProductDiscountConsoleCommand>()
                .AddSingleton<IConsoleCommand, PrintCheckConsoleCommand>()
                .AddSingleton<IConsoleCommand, UndoConsoleCommand>()
                .AddSingleton<IConsoleCommand, RedoConsoleCommand>()
                .AddTransient<IConsoleCommand, ExitConsoleCommand>();
        }
    }
}