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

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }

}