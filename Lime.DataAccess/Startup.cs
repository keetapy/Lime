using Lime.DataAccess.Repository;
using Lime.DataAccess.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.SqlClient;

namespace Lime.DataAccess
{
    public static class Startup
    {
        static public void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDatabaseConnection>((context) => new DatabaseConnection(connectionString));
            services.AddTransient<IRepository, TestRepository>();


        }
    }
}
