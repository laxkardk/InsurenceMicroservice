using CustomerPolicyServices.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerPolicyServices.Context
{
    public class ServiceDbContext : DbContext, IServiceDbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
            : base(options)
        {

        }

        public DbSet<CustomerPolicy> CustomerPolicy { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

       
       }
}
