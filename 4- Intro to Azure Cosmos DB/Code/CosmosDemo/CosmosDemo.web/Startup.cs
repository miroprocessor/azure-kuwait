using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmosDemo.web.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CosmosDemo.web
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
            services.AddControllersWithViews();

            //services.AddEntityFrameworkSqlServer()
            //    .AddDbContext<EmployeeDbContext>(options =>
            //                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddEntityFrameworkCosmos()
                .AddDbContext<EmployeeDbContext>(options =>
                {
                    options.UseCosmos(Configuration.GetSection("AppSettings").GetValue<string>("EndPoint"),
                        Configuration.GetSection("AppSettings").GetValue<string>("Cosmoskey"),
                        databaseName: Configuration.GetSection("AppSettings").GetValue<string>("DatabaseName"));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
