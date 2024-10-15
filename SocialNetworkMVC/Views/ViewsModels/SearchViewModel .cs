using SocialNetworkMVC.Models;

namespace SocialNetworkMVC.Views.ViewsModels
{
    public class SearchViewModel
    {
        public List<UserWithFriendExt> UserList { get; set; }
        public SearchViewModel()
        {
            UserList = new List<UserWithFriendExt>();
        }
    }
}
