using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTracker.Data.Context
{
    // DbContext --> represents a session to a db and provides APIs
    // to communicate with the db
    public class PersonalHealthTrackerDbContext : IdentityDbContext<AppUser>
    {
        // Per Model that we want to turn into a table
        // we add it as a DbSet

        // represents a collection (table) of a given entity/model
        // they map to tables by default
        public DbSet<Physical_Activity> Physical_Activities { get; set; }
        public DbSet<Physical_Activity_Type> Physical_Activity_Types { get; set; }
        
        public DbSet<Mental_Activity> Mental_Activities { get; set; }
        public DbSet<Mental_Activity_Type> Mental_Activity_Types { get; set; }

        public DbSet<Nutrition> Nutrition { get; set; }
        public DbSet<Nutrition> Nutrition_Types { get; set; }

        public DbSet<Sleep> Sleep { get; set; }

        // virtual method designed to be overridden
        // you can provide configuration information for the context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connection string is divided in 3 elements
            // server - database - authentication
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PersonalHealthTracker;Trusted_Connection=true");
        }

        // We can manipulate the models
        // Add data to table
        // change the default relationships
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base = IdentityDbContext
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Physical_Activity_Type>().HasData(
                    new Physical_Activity_Type {Id=1, Description = "Jogging"},
                    new Physical_Activity_Type {Id=2, Description = "Walking" },
                    new Physical_Activity_Type {Id=3, Description = "Swimming" }
                );

            modelBuilder.Entity<Mental_Activity_Type>().HasData(
                    new Mental_Activity_Type { Id = 1, Description = "Crossword" },
                    new Mental_Activity_Type { Id = 2, Description = "Sudoku" },
                    new Mental_Activity_Type { Id = 3, Description = "Reading" }
                );

            modelBuilder.Entity<Nutrition_Type>().HasData(
                   new Nutrition_Type { Id = 1, Description = "Steak" },
                   new Nutrition_Type { Id = 2, Description = "Bread" },
                   new Nutrition_Type { Id = 3, Description = "Apple" },
                   new Nutrition_Type { Id = 4, Description = "Milk" }

               );
        }
    }
}
