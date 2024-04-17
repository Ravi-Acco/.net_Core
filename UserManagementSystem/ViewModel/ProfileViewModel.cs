using System.ComponentModel.DataAnnotations;

namespace UserManagementSystem.ViewModel
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        [Required] 
        public string? Title { get; set; }
        
        public string? Description { get; set; }
        [Required] 
        public string? Color { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? UserId { get; set; }
    }
}
