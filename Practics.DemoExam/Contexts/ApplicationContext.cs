using System.Data.Entity;
using Practics.DemoExam.Models;

namespace Practics.DemoExam.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ReceivingPoint> ReceivingPoints { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext() : base("GoodsStore") { }
    }
}