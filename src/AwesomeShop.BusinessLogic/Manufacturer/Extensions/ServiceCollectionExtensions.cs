using AwesomeShop.BusinessLogic.DeliveryCountry.Services;
using AwesomeShop.BusinessLogic.Manufacturer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Sieve.Services;

namespace AwesomeShop.BusinessLogic.DeliveryCountry.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductsCrudServices(this IServiceCollection serviceCollection) =>
            serviceCollection.AddScoped<IManufacturerService, ManufacturerService>()
                .AddScoped<ISieveProcessor, SieveProcessor>();
    }
}