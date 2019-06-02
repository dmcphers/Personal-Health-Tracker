using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalHealthTracker.Domain.Model
{
    public class Mental_Activity
    {
        public int Id { get; set; } // for DB purposes to make it be identifiable

        [Required]
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [Display(Name = "Day of Week")]
        public DayOfWeek dayOfWeek { get; set; }

        // Fully Defined Relationship for Mental Activity Type
        [Display(Name = "Mental Activity")]
        public int Mental_Activity_TypeId { get; set; }
        public Mental_Activity_Type Mental_Activity_Type { get; set; }

        // Fully Defined Relationship for App User
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
