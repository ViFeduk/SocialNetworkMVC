using System.ComponentModel.DataAnnotations;

namespace SocialNetworkMVC.Views.ViewsModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "День")]
        public string Day { get; set; } = "1";
        [Required]
        [Display(Name = "Месяц")]
        public string Month { get; set; } = "1";
        [Required]
        [Display(Name = "Год")]
        public string Year { get; set; } = "1";
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        public string PasswordReg { get; set; }
        [Required]
        [Compare("PasswordReg", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
        [Required]
        [Display(Name = "Никнейм")]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Почта")]
        [EmailAddress(ErrorMessage = "Некорректная почта")]
        public string EmailReg { get; set; }
    }
}
