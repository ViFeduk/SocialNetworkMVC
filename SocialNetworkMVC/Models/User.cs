using Microsoft.AspNetCore.Identity;
using static System.Net.Mime.MediaTypeNames;

namespace SocialNetworkMVC.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string? MidleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Image { get; set; }

        public string Status { get; set; }

        public string About { get; set; }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        public User()
        {
            Image = "https://via.placeholder.com/500";
            Status = "Ура! Я в соцсети!";
            About = "Информация обо мне.";
        }
    }
}
