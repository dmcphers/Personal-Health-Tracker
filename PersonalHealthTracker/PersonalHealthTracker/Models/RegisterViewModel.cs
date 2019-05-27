using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalHealthTracker.Models
{
    public class RegisterViewModel
    {
        [EmailAddress, Required]
        public string Email { get; set; }

        [DataType(DataType.Password), Required]
        public string Password { get; set; }

        [DataType(DataType.Password), Required]
        [Compare(nameof(Password), ErrorMessage ="The passwords did not match")]
        public string ConfirmPassword { get; set; }
    }
}
