using Microsoft.Extensions.DependencyInjection;

namespace rewriter.OrderService
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddOrderService(this IServiceCollection services)
        {
            services.AddSingleton<IOrderService, OrderService>();
            return services;
        }
    }
}