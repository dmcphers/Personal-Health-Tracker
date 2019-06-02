using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PersonalHealthTracker.Domain.Model
{
    public class Mental_Activity_Type
    {
        public int Id { get; set; } // PK in DB table

        [Required]  // Make sure that any entry contains a description
        public string Description { get; set; }
    }
}
