using Microsoft.EntityFrameworkCore;

namespace Uyg.API.Models
{
    public class AppDbContext:DbContext
    {
      public DbSet<Product> Products { get; set; }
      public DbSet<Category> Categories { get; set; }


        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
    
}
