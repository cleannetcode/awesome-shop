using AwesomeShop.BusinessLogic.Accounts.Interfaces;
using AwesomeShop.BusinessLogic.Accounts.Requests;
using AwesomeShop.BusinessLogic.Accounts.Services;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserServices(this IServiceCollection serviceCollection, IConfiguration configuration) =>
            serviceCollection.Configure<TokenIssuerOptions>(options => configuration.Bind(TokenIssuerOptions.Section, options))
                .AddScoped<ITokenService, TokenService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IUserClaimsFactory, UserClaimsFactory>()
                .AddSingleton<IHasher, Hasher>()
                .AddScoped<IUserCommonRepository, UserCommonRepository>()
                .AddScoped<IAdminService, AdminService>();
    }
}