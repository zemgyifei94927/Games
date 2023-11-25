﻿using GamesWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Action", DisplayOrder = 1},
                    new Category { Id = 2, Name = "Horor", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "RPG", DisplayOrder = 3 }
                );
        }
    }
}
