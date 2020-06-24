using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Entities;

namespace Infrastructure.Data.Entity_Framework
{
    public class DatabaseContext : DbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }  

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
