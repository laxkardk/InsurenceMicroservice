using Insurance.CustomerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Insurance.CustomerAPI.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
