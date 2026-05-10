using Microsoft.AspNetCore.Identity;

namespace DunesOfArabia.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string PassportNumber { get; set; }
        public string Role { get; set; } = "User"; // "User" or "Admin"
    }
}