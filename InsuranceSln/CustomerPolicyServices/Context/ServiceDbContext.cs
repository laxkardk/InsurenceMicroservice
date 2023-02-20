using CustomerPolicyServices.Model;
using Microsoft.EntityFrameworkCore;

namespace CustomerPolicyServices.Context
{
    public class ServiceDbContext : DbContext, IServiceDbContext
    {
        public ServiceDbContext(DbContextOptions<ServiceDbContext> options)
            : base(options)
        {

        }

        public DbSet<CustomerPolicy> CustomerPolicies { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");
        //        optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=CustomerPolicyDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        //    }
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
