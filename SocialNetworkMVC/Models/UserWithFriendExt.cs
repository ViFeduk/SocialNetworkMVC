namespace SocialNetworkMVC.Models
{
    public class UserWithFriendExt:User
    {
        public bool IsFriendWithCurrent { get; set; }
        public bool IsCurrentUser { get; set; }
    }
}
