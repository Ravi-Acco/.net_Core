﻿namespace UserManagementSystem.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string? UserId { get; set; }
        public User? User  { get; set; }
    }
}
