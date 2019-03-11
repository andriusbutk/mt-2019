using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MunicipalitiesTax.Api.Middlewares;
using MunicipalitiesTax.DataEF.Context;
using MunicipalitiesTax.DataEF.Repositories;
using MunicipalitiesTax.Domain.Repositories;
using MunicipalitiesTax.Domain.Services;
using MunicipalitiesTax.ServiceImpementation.Services;
using Newtonsoft.Json;
using System.IO;

namespace MunicipalitiesTax.Api
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true);

            var config = configBuilder.Build();

            // Services
            services.AddScoped<IMunicipalitiesService, MunicipalitiesService>();

            // Repositories
            services.AddScoped<IMunicipalitiesTaxRepository, MunicipalitiesTaxRepository>();
            services.AddScoped<IMunicipalitiesRepository, MunicipalitiesRepository>();

            services.AddDbContext<MunicipalityContext>(options =>
                options.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=MunicipalityContext;Integrated Security=True;MultipleActiveResultSets=True"));

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<ApiExceptionMiddleware>();

            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
