using Microsoft.EntityFrameworkCore;

namespace MyFilms.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<string> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
