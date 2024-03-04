using Microsoft.EntityFrameworkCore;

namespace uyg02.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
