using ConfirmitTest.Core;
using Microsoft.Extensions.DependencyInjection;

namespace ConfirmitTest.App
{
    public static class RegisterDefaultCommandExtension
    {
        public static IServiceCollection AddDefaultConsoleCommand<T>(this IServiceCollection services)
            where T : class, IDefaultConsoleCommand
        {
            return services.AddSingleton<IDefaultConsoleCommand, T>();
        }
    }
}