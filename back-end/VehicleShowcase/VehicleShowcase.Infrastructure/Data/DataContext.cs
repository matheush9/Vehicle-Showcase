using Microsoft.EntityFrameworkCore;
using VehicleShowcase.Domain.Entities;

namespace VehicleShowcase.Infrastructure.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles => Set<Vehicle>();
        public DbSet<Admin> Admins => Set<Admin>();
    }
}