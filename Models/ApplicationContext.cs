using Microsoft.EntityFrameworkCore;
using MyFilms.Models.DbModels;

namespace MyFilms.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Release> Releases { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { Id = 1, UserName = "hhh", Email = "hhh", PasswordHash = "hhh".GetHashCode(), IsStaff = false });
        }
    }
}