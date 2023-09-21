using Microsoft.EntityFrameworkCore;
using SiteECommerce_TP_.Models;

namespace SiteECommerce_TP_.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
