using Application;
using Application.DataServices;
using Application.Services;
using AutoMapper;
using Domain.Configuration;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

            services.AddScoped<JobScraperRunner>();
            services.AddScoped<DataService>();
            services.AddScoped<CvOnlineScrapeService>();
            services.AddScoped<CvBankasScrapeService>();
            services.AddScoped<CvMarketScrapeService>();
            services.AddScoped<UnitOfWork>();
            services.AddScoped<CvBankasConfiguration>();
            services.AddScoped<CvOnlineConfiguration>();
            services.AddScoped<CvMarketConfiguration>();
            services.AddScoped<CvOnlineDataService>();
            services.AddScoped<CvBankasDataService>();
            services.AddScoped<CvMarketDataService>();
            services.AddScoped<CvOnlineRepostory>();
            services.AddScoped<CvBankasRepository>();
            services.AddScoped<CvMarketRepository>();

            services.AddScoped<CompanyService>();

            services.AddDbContext<DataContext>(options
                => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
