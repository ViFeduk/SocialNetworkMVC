using SocialNetworkMVC.Models;

namespace SocialNetworkMVC.Views.ViewsModels
{
    public class UserEditViewModel
    {
        public User User { get; set; }
        public UserEditViewModel(User user)
        {
            User = user; 
           
        }
        public UserEditViewModel()
        {
               
        }
    }
}
