﻿using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Configuration;

namespace JobScraper.Application
{
	class Program
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
            services.AddTransient<JobScraperRunner>();

            services.AddDbContext<DataContext>(options 
                => options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()));

            return services;
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}
