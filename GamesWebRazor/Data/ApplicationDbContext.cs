﻿using GamesWebRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesWebRazor.Data
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
                    new Category { Id = 1, Name = "Action", DisplayOrder = 3 },
                    new Category { Id = 2, Name = "Horor", DisplayOrder = 1 },
                    new Category { Id = 3, Name = "RPG", DisplayOrder = 2 }
                );
        }
    }
}
