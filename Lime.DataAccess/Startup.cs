using Lime.DataAccess.DbContext;
using Lime.DataAccess.Entities;
using Lime.DataAccess.Repository;
using Lime.DataAccess.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Lime.DataAccess
{
    public static class Startup
    {
        static public void ConfigureServices(IServiceCollection services, string connectionString)
        {
            //////new code////
            services.AddDbContext<UsersDbContext>(options =>
                 options.UseSqlServer(connectionString));
            services.AddIdentity<User, IdentityRole>()
               .AddEntityFrameworkStores<UsersDbContext>();
            /////////////////
            services.AddScoped<IDatabaseConnection>((context) => new DatabaseConnection(connectionString));
            services.AddTransient<IRepository, UsersRepository>();


        }
    }
}
