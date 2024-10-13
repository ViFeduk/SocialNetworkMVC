using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetworkMVC.Models;

namespace SocialNetworkMVC.DataBase
{
    public class MyAppContext: IdentityDbContext<User>
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {
          
            Database.EnsureCreated();
        }
    }
}
