using rewriter.OrderService;
using rewriter.Settings;

namespace rewriter.api
{
    public static class Bootstrapper
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddSettings()
                .AddOrderService();
        }
    }
}
