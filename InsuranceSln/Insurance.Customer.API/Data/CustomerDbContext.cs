using Insurance.CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Insurance.CustomerAPI.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<Customer>()
                .HasIndex(u => u.Mobile)
                .IsUnique();
        }
    }
}
