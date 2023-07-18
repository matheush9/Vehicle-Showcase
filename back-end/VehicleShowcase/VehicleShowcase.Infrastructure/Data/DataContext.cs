using Microsoft.EntityFrameworkCore;

namespace VehicleShowcase.Infrastructure.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}