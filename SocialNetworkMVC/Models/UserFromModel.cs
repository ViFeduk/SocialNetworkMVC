using SocialNetworkMVC.Views.ViewsModels;

namespace SocialNetworkMVC.Models
{
    public static class UserFromModel
    {
        public static User Convert(this User user, UserEditViewModel usereditvm)
        {
            user.Image = usereditvm.User.Image;
            user.LastName = usereditvm.User.LastName;
            user.MidleName = usereditvm.User.MidleName;
            user.FirstName = usereditvm.User.FirstName;
            user.Email = usereditvm.User.Email;
            user.DateBirth = usereditvm.User.DateBirth;
            user.UserName = usereditvm.User.UserName;
            user.Status = usereditvm.User.Status;
            user.About = usereditvm.User.About;

            return user;
        }
    }
}
