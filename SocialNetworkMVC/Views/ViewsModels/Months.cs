using System.ComponentModel.DataAnnotations;

namespace SocialNetworkMVC.Views.ViewsModels
{
    public enum Months
    {
        [Display( Name ="Январь")]
        Jan = 1,
        [Display( Name ="Февраль")]
        Feb = 2,
        [Display( Name ="март")]
        March = 3,
        [Display( Name ="апрель")]
        April = 4,
        [Display( Name ="май")]
        May = 5,
        [Display( Name ="Июнь")]
        June = 6,
        [Display( Name ="июль")]
        July = 7,
        [Display( Name ="Август")]
        August = 8,
        [Display( Name ="Сентябрь")]
        September = 9,
        [Display( Name ="Октябрь")]
        October = 10,
        [Display( Name ="Ноябрь")]
        Novem = 11,
        [Display( Name ="Декабрь")]
        Decem = 12,

    }
}
