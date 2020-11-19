using Lime.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lime.DataAccess.DbContext
{
    public class UsersDbContext: IdentityDbContext<User>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<ApartmentAddress> ApartmentAddresses { get; set; }
        public DbSet<ApartmentType> ApartmentTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<DealType> DealTypes { get; set; }
        public DbSet<InternetProvider> InternetProviders { get; set; }
        public DbSet<RentalDeal> RentalDeals { get; set; }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }
}
