using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalHealthTracker.Domain.Model
{
    public class Sleep
    {
        public int Id { get; set; } // for DB purposes to make it be identifiable

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Hours")]
        public int Hours { get; set; }

        [Required]
        
        public DateTime Date { get; set; }

        // Fully Defined Relationship for App User
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
