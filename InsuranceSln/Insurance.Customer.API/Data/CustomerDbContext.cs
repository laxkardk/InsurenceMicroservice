using Insurance.CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Insurance.CustomerAPI.Data
{
    /// <summary>
    /// Customer Database Entity Context to peroform DDL & DML operations
    /// </summary>
    public class CustomerDbContext : DbContext
    {
        /// <summary>
        /// Defulat Initiliaztion
        /// </summary>
        /// <param name="options">Databse Context options</param>
        public CustomerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Customer DataTable Set
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// On Model Creating
        /// </summary>
        /// <param name="builder">Model Builder</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Email Unique Key Constraint
            builder.Entity<Customer>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Mobile Unique Key Constraint
            builder.Entity<Customer>()
                .HasIndex(u => u.Mobile)
                .IsUnique();
        }
    }
}
