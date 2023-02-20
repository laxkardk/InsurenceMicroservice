using Microsoft.EntityFrameworkCore;
using PolicyMasterService.Models;

namespace PolicyMasterService.Data
{
    public class PolicyMasterDBContext : DbContext
    {
        public PolicyMasterDBContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<PolicyMasterEntity> PolicyMaster { get; set; }
    }
}
