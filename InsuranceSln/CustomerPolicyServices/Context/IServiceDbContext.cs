using CustomerPolicyServices.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CustomerPolicyServices.Context
{
    public interface IServiceDbContext
    {
        DbSet<CustomerPolicy> CustomerPolicies { get; set; }

        Task<int> SaveChangesAsync();
    }
}
