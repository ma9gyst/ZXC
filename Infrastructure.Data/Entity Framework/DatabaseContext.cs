using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;

namespace Infrastructure.Data.Entity_Framework
{


    public class DatabaseContext : IdentityDbContext<AppUser, ApplicationRole, int>
    {
        public DbSet<News> News { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Matchup> Matchups { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) 
        //{
        //    modelBuilder.Entity<Hero>().HasData(new Hero[]
        //    {
        //        new Hero
        //        {

        //        }
        //    });
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
    }
}