using Insurance.PurchaseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Insurance.PurchaseAPI.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {



        }
        public DbSet<PurchaseInsuranceEntity> PurchaseInsurance { get; set; }
    }
}
