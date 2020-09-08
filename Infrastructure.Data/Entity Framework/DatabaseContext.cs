using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data.Entity_Framework
{


    public class DatabaseContext : IdentityDbContext<AppUser, ApplicationRole, int>
    {
        public DbSet<News> News { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Hero> Heroes { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
    }
}