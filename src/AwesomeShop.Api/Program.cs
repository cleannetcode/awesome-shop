using System.Threading.Tasks;
using AwesomeShop.Data;
using AwesomeShop.Data.Development;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;

namespace AwesomeShop.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IdentityModelEventSource.ShowPII = true;
            var host = CreateHostBuilder(args).Build();
            await MigrateAsync(host);

            await host.RunAsync();
        }

        private static async Task MigrateAsync(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var environment = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
            await using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();
            if (environment.IsDevelopment() && !await context.Products.AnyAsync())
            {
                var demoData = new DemoData();
                context.AddRange(demoData.Products);
                context.AddRange(demoData.Orders);
                await context.SaveChangesAsync();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}