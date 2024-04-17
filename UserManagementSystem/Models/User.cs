using Microsoft.AspNetCore.Identity;

namespace UserManagementSystem.Models
{
    public class User: IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Profile>? Profiles { get; set; }
    }
}
