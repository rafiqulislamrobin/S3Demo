using Demo.Customer.Entites;
using Microsoft.EntityFrameworkCore;

namespace Demo.Customer.Context

{
    public class BookingDbContext : DbContext, IBookingDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public BookingDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerEO>();


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CustomerEO> Customers { get; set; }
    }
}
