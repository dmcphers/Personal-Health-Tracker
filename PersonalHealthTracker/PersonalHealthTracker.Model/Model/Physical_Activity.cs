using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalHealthTracker.Domain.Models
{
    public class Physical_Activity
    {

        public int Id { get; set; } // for DB purposes to make it be identifiable

        [Required]
        public string Description { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [Display(Name ="Calories Burned")]
        public int CaloriesBurned { get; set; }

        [Required]
        [Display(Name ="Day of Week")]
        public DayOfWeek dayOfWeek { get; set; }

        // Fully Defined Relationship
        public int Physical_Activity_TypeId { get; set; }
        public Physical_Activity_Type Physical_Activity_Type { get; set; }
    }
}
