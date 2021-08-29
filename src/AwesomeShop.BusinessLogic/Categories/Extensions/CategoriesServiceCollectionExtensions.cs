using AwesomeShop.BusinessLogic.Categories.Interfaces;
using AwesomeShop.BusinessLogic.Categories.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CategoriesServiceCollectionExtensions
    {
        public static IServiceCollection AddCategoriesCrudServices(this IServiceCollection serviceCollection) =>
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
    }
}