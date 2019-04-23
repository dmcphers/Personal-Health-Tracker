using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalHealthTracker.Models
{
    public class Physical_Activity
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }

        [Display(Name ="Calories Burned")]
        public int CaloriesBurned { get; set; }

        [Display(Name ="Day of Week")]
        public DayOfWeek dayOfWeek { get; set; }
    }
}
