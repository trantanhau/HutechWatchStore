using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RolexStore.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please fill your email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please fill your password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}