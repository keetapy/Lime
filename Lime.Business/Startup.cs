using Lime.Business.Services;
using Lime.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Lime.Business
{
    public static class Startup
    {
        static public void ConfigureServices(IServiceCollection services, string connectionString)
        {

            services.AddTransient<ITestService, TestService>();
            DataAccess.Startup.ConfigureServices(services, connectionString);
        }
    }
}
