using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lime.Business.Services;
using Lime.Business.Services.Interfaces;
using Lime.DataAccess.Repository;
using Lime.DataAccess.Repository.Interfaces;
using Lime.WebAPI.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Lime.WebAPI
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
            services.AddTransient<IRepository, testRepository>();
            services.AddTransient<ITestService, testService>();
            //services.AddTransient<ITestService, testController>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

               
                // определение маршрутов
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=test}/{action=getdata}/{id?}");
            });
        }
    }
}
