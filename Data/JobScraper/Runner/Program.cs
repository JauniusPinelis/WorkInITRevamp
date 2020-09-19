using Application;
using Application.Configuration;
using Application.DataServices;
using Application.Interfaces;
using Application.Services;
using AutoMapper;
using Domain;
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

            using (var client = new DataContext())
            {
                client.Database.Migrate();
            }

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
            services.AddScoped<CvMarketScrapeService>();
            services.AddScoped<UnitOfWork>();
            services.AddScoped<IScraper, Scraper>();
            services.AddScoped<CvBankasConfiguration>();
            services.AddScoped<CvOnlineConfiguration>();
            services.AddScoped<CvMarketConfiguration>();
            services.AddScoped<CvOnlineDataService>();
            services.AddScoped<CvBankasDataService>();
            services.AddScoped<CvMarketDataService>();
            services.AddScoped<CvOnlineRepostory>();
            services.AddScoped<CvBankasRepository>();
            services.AddScoped<CvMarketRepository>();

            services.AddDbContext<DataContext>(options
                => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            //Automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


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
