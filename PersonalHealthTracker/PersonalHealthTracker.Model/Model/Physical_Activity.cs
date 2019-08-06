using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalHealthTracker.Domain.Model
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
        public DateTime Date { get; set; }



        //Fully Defined Relationship for Property Type
        [Display(Name = "Physical Activity")]
        public int Physical_Activity_TypeId { get; set; }
        public Physical_Activity_Type Physical_Activity_Type { get; set; }

        // Fully Defined Relationship for App User
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
