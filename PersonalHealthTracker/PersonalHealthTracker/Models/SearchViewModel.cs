using PersonalHealthTracker.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalHealthTracker.Models
{
    public class SearchViewModel
    {
        public DateRangeViewModel dateRangeViewModel { get; set; }
        public DateViewModel dateViewModel { get; set; }
    }
}
