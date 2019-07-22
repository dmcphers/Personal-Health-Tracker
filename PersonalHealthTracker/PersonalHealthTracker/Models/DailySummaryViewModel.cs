using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalHealthTracker.Models
{
    public class DailySummaryViewModel
    {
        public ICollection<Physical_Activity> PA { get; set; }
        public ICollection<Mental_Activity> MA { get; set; }
        public ICollection<Nutrition> NUT { get; set; }
        public ICollection<Sleep> SLP { get; set; }
    }
}
