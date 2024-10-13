using System.ComponentModel.DataAnnotations;

namespace SocialNetworkMVC.Views.ViewsModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Не введено имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не введена фамилия")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Не введен день рождения")]
        [Display(Name = "День")]
        public string Day { get; set; }
        [Required(ErrorMessage = "Не введен месяц рождения")]
        [Display(Name = "Месяц")]
        public string Month { get; set; }
        [Required(ErrorMessage = "Не введен год рождения")]
        [Display(Name = "Год")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Пароль не введен")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        [StringLength(100, ErrorMessage = "Поле {0} должно иметь минимум {2} и максимум {1} символов.", MinimumLength = 5)]
        public string PasswordReg { get; set; }
        [Required]
        [Compare("PasswordReg", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
        [Required(ErrorMessage = "Не введен никнейм")]
        [Display(Name = "Никнейм")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не введена почта")]
        [Display(Name = "Почта")]
        [EmailAddress(ErrorMessage = "Некорректная почта")]
        public string EmailReg { get; set; }
    }
}
