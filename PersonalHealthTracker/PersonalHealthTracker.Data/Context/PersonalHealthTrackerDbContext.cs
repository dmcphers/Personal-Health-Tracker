using Microsoft.EntityFrameworkCore;
using PersonalHealthTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTracker.Data.Context
{
    // DbContext --> represents a session to a db and provides APIs
    // to communicate with the db
    public class PersonalHealthTrackerDbContext : DbContext
    {
        // Per Model that we want to turn into a table
        // we add it as a DbSet

        // represents a collection (table) of a given entity/model
        // they map to tables by default
        public DbSet<Physical_Activity> Physical_Activities { get; set; }

        // virtual method designed to be overridden
        // you can provide configuration information for the context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connection string is divided in 3 elements
            // server - database - authentication
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PersonalHealthTracker;Trusted_Connection=true");
        }
    }
}
