using Microsoft.EntityFrameworkCore;

namespace subject.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<subject.Model.Subject> Subjects { get; set; }
    }
}
