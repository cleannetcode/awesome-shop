using AwesomeShop.BusinessLogic.Products.Interfaces;
using AwesomeShop.BusinessLogic.Products.Services;
using Sieve.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ProductsServiceCollectionExtensions
    {
        public static IServiceCollection AddProductsCrudServices(this IServiceCollection serviceCollection) =>
            serviceCollection.AddScoped<IProductService, ProductService>()
                .AddScoped<ISieveProcessor, SieveProcessor>();
    }
}