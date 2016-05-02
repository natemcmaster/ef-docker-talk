using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace PortableWebApp
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IHostingEnvironment env)
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables()
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddDbContext<StoreContext>(
               o => o.UseNpgsql(_config["Npgsql:ConnectionString"]));

        }

        public void Configure(IApplicationBuilder app,
                DbContextOptions<StoreContext> options,
                ILoggerFactory loggerFactory,
                IHostingEnvironment env)
        {
            loggerFactory.AddConsole(LogLevel.Information);

            SeedDatabase(options, loggerFactory.CreateLogger("SeedDatabase"));

            app.Run(async context =>
            {
                context.Response.ContentType = "application/json; charset=UTF-8";
                using (var db = new StoreContext(options))
                {
                    var customers = db.Customers.ToArray();
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(customers));
                }
            });
        }

        private void SeedDatabase(DbContextOptions<StoreContext> options, ILogger logger)
        {
            using (var db = new StoreContext(options))
            {
                // This is currently the only way to run migrations when
                // the app is inside a docker container.
                // in most other usages, it is better to use 'dotnet ef database update'
                // or to use 'dotnet ef migrations script' to apply migrations
                db.Database.Migrate();


                if (db.Customers.Count() == 0)
                {
                    db.AddRange(SeedData.CreateCustomers());
                    var changes = db.SaveChanges();
                    logger.LogInformation($"Added {changes} new customers to database");
                }
                else
                {
                    logger.LogInformation("Database already has data. Skipping seeding");
                }
            }
        }
    }
}