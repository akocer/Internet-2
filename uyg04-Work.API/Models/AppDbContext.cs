using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace uyg04_Work.API.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {

        public DbSet<Work> Works { get; set; }
        public DbSet<WorkStep> WorkSteps { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
