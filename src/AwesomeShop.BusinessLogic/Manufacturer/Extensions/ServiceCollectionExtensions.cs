using AwesomeShop.BusinessLogic.Manufacturer.Interfaces;
using AwesomeShop.BusinessLogic.Manufacturer.Services;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;

namespace AwesomeShop.BusinessLogic.Manufacturer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductsCrudServices(this IServiceCollection serviceCollection) =>
            serviceCollection.AddScoped<IManufacturerService, ManufacturerService>()
                .AddScoped<ISieveProcessor, SieveProcessor>();
    }
}