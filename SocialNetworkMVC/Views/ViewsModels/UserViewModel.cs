﻿using SocialNetworkMVC.Models;

namespace SocialNetworkMVC.Views.ViewsModels
{
    public class UserViewModel
    {
        public User User { get; set; }
        public List<User>? Friends { get; set; }
        public UserViewModel(User user)
        {
            User = user;
           
        }

    }
}
