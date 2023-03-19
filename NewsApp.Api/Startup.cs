using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NewsApp.Core.Services.Contracts;
using NewsApp.Core.Services.Implementations;
using NewsApp.Proxy.Services.Contracts;
using NewsProxy.Services.Implementations;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;

namespace NewsApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // agregamos el archivo appsettings.json de Proxy
    .Build();
            services.AddControllers();
            services.AddHttpClient();
            services.AddHttpClient<INewApiProxysService, NewsApiProxyService>();
            services.AddSingleton<HttpClient>();
            services.AddSingleton<INewsDataProvider, ApiProxyDataProvider>();
            services.AddSingleton<INewsQueryBuilder, DefaultNewsQueryBuilder>();
            services.AddSingleton<INewsService, NewsService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NewsApp",
                    Version = "v1",
                    Description = "Api para obtener noticias",
                    Contact = new OpenApiContact
                    {
                        Name = "Matias Velasquez",
                        Email = "matiasvelasquez840@gmail.com",
                    },
                });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewsApp v1");
            });
        }
    }
}
