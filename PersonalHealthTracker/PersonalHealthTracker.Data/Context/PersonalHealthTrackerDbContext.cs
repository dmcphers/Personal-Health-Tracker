using Microsoft.EntityFrameworkCore;
using PersonalHealthTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTracker.Data.Context
{
    // This class will translate Models into Database tables
    public class PersonalHealthTrackerDbContext : DbContext
    {
        // Per Model that we want to turn into a table
        // we add it as a DbSet

        DbSet<Physical_Activity> Physical_Activities { get; set; }
    }
}
