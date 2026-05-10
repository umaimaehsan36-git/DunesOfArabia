using Microsoft.AspNetCore.Identity;

namespace DunesOfArabia.Models
{
    public class ApplicationUser : IdentityUser
    {
        // You can extend later
        public string? FullName { get; set; }
    }
}