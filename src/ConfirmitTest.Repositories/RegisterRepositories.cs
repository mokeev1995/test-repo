using Microsoft.Extensions.DependencyInjection;

namespace ConfirmitTest.Repositories
{
    public static class RegisterRepositories
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<ICartCouponRepository, CartCouponRepository>()
                .AddScoped<IProductCouponRepository, ProductCouponRepository>();
        }
    }
}