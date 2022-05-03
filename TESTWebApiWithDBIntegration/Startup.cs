using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TESTDBAccessLib;
using TESTDBAccessLib.Models;
using TESTDBAccessLib.Repository;

namespace TESTWebApiWithDBIntegration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseStaticFiles();
            app.UseRouting();
            //app.UseCors();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            string connectionString = Configuration.GetConnectionString("Default");

            services.AddDbContext<WebApiCoreContext>(builder =>
                builder.UseSqlServer(connectionString, b => b.MigrationsAssembly("TESTWebApiWithDBIntegration"))
                );

            services.AddScoped<IRepository<CustomerModel>, CustomerRepository>();
            services.AddScoped<IRepository<CurrentWeatherModel>, WeatherRepository>();
        }
    }
}
