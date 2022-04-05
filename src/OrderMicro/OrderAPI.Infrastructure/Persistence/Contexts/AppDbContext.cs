using OrderAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace OrderAPI.Infrastructure.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
