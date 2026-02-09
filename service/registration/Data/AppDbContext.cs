using Microsoft.EntityFrameworkCore;
using registration.Model;

namespace registration.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Registration> Registrations { get; set; }
    }
}
