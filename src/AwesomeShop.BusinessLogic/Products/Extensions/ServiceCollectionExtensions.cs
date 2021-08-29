using AwesomeShop.BusinessLogic.Products.Interfaces;
using AwesomeShop.BusinessLogic.Products.Services;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;

namespace AwesomeShop.BusinessLogic.Products.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductsCrudServices(this IServiceCollection serviceCollection) =>
            serviceCollection.AddScoped<IProductService, ProductService>()
                .AddScoped<ISieveProcessor, SieveProcessor>();
    }
}