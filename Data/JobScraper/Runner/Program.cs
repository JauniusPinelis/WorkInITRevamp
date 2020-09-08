using Application;
using Application.Services;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.IO;

namespace Runner
{
    public class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();

            var serviceProvider = services.BuildServiceProvider();

            // calls the Run method in App, which is replacing Main
            serviceProvider.GetService<JobScraperRunner>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {

            IServiceCollection services = new ServiceCollection();

            var config = LoadConfiguration();
            services.AddSingleton(config);

            // required to run the application

            services.AddScoped<JobScraperRunner>();
            services.AddScoped<DataService>();
            services.AddScoped<CvOnlineScrapeService>();
            services.AddScoped<CvBankasScrapeService>();
            services.AddScoped<JobUrlRepository>();

            services.AddDbContext<DataContext>(options
                => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
