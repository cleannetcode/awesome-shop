using AwesomeShop.BusinessLogic.Orders.Interfaces;
using AwesomeShop.BusinessLogic.Orders.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class OrderServiceCollectionExtensions
    {
        public static IServiceCollection AddOrdersServices(this IServiceCollection serviceCollection) =>
            serviceCollection
                .AddScoped<IOrderVisualizer, OrderVisualizer>()
                .AddScoped<IOrderService, OrderService>();
    }
}