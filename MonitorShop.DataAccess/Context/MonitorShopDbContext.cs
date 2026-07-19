using Microsoft.EntityFrameworkCore;
using MonitorShop.Entities;

namespace MonitorShop.DataAccess.Context
{
    public class MonitorShopDbContext : DbContext
    {
        public MonitorShopDbContext(DbContextOptions<MonitorShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}