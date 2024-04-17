using System.ComponentModel.DataAnnotations;

namespace UserManagementSystem.ViewModel
{
    public class ChangeEmailViewModel
    {
        [Required]
        [Display(Name = "New Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Confirm Confirm")]
        [Compare("Email")]
        public string EmailConfirmed { get; set; }
    }
}
