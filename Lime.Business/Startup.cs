using Lime.Business.Services;
using Lime.Business.Services.Interfaces;
using Lime.DataAccess.DbContext;
using Lime.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.Business
{
    public static class Startup
    {
        static public void ConfigureServices(IServiceCollection services, string connectionString, IConfiguration configuration)
        {
            services.AddTransient<IAuthorizationService, AuthorizationService>();
            DataAccess.Startup.ConfigureServices(services, connectionString);
        }
    }
}
