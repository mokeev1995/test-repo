using Microsoft.Extensions.DependencyInjection;

namespace ConfirmitTest.Shop
{
    public static class RegisterCartService
    {
        public static IServiceCollection AddCartService<T>(this IServiceCollection services)
            where T: class, ICartService
        {
            return services.AddSingleton<ICartService, T>();
        }
    }
}