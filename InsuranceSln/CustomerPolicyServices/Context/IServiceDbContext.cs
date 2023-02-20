using CustomerPolicyServices.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CustomerPolicyServices.Context
{
    public interface IServiceDbContext
    {
        DbSet<CustomerPolicy> CustomerPolicy { get; set; }

        Task<int> SaveChangesAsync();
    }
}
