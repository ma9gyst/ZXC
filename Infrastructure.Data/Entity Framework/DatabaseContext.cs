using Microsoft.EntityFrameworkCore;
using Domain.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Data.Entity_Framework
{
    public class DatabaseContext : IdentityDbContext<AppUser, ApplicationRole, int>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    
        public DbSet<News> News { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Picture> Pictures{ get; set; }
    }
}