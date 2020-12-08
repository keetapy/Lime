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
            services.AddTransient<IApartmentRepository, ApartmentsRepository>();
            services.AddTransient<IAmenitiesRepository, AmenitiesRepository>();
            services.AddTransient<IApartmentsAddressesRepository, ApartmentAddressesRepository>();
            services.AddTransient<IAmenitiesApartmentRepository, AmenitiesApartmentRepository>();
            services.AddTransient<IInternetProvidersRepository, InternetProvidersRepository>();
            services.AddTransient<IClientsRepository, ClientsRepository>();
            services.AddTransient<IApartmentsTypesRepository, ApartmentTypesRepository>();
            services.AddTransient<IDealTypesRepository, DealTypesRepository>();
            services.AddTransient<IRentalDealsRepository, RentalDealsRepository>();
            services.AddTransient<ILogsRepository, LogsRepository>();

        }
    }
}
