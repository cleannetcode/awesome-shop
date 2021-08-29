using System.Text;
using AwesomeShop.Api.Shared;
using AwesomeShop.BusinessLogic.Accounts.Requests;
using AwesomeShop.BusinessLogic.Products.Mapping;
using AwesomeShop.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace AwesomeShop.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ApplicationExceptionFilter>();

            services.AddControllers(options =>
                options.Filters.Add<ApplicationExceptionFilter>());
            
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                    _configuration.GetConnectionString("DefaultConnection"), options =>
                        options.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
            );
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new()
                    {
                        Title = "AwesomeShop.Api", Version = "v1"
                    });
                })
                .AddUserServices(_configuration)
                .AddProductsCrudServices()
                .AddCategoriesCrudServices();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    _configuration.Bind(TokenIssuerOptions.Section, options);
                    var tokenOptions = new TokenIssuerOptions();
                    _configuration.Bind(TokenIssuerOptions.Section, tokenOptions);
                    options.TokenValidationParameters.IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenOptions.Secret));
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("Default", builder => builder.RequireAuthenticatedUser());
            });

            services.AddAutoMapper(typeof(ProductProfile).Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AwesomeShop.Api v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}