using Microsoft.AspNetCore.Identity;

namespace SocialNetworkMVC.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string? MidleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
    }
}
