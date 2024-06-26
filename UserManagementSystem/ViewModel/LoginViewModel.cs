﻿using System.ComponentModel.DataAnnotations;

namespace UserManagementSystem.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string? Username{ get; set; }
        [Required] 
        public string? Password{ get; set; }
        [Display(Name ="Remember Me")] 
        public bool RememberMe{ get; set; }
    }
}
