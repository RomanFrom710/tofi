using System.ComponentModel.DataAnnotations;
using BLL.Attributes;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.User.ViewModels
{
    public class RegisterViewModel : ModelViewModel
    {
        [CustomRequired]
        [EmailAddress(ErrorMessage = "Неправильный формат адреса электронной почты.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [CustomRequired]
        [StringLength(100, ErrorMessage = "{0} должен содержать минимум {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string ConfirmPassword { get; set; }

        [CustomRequired]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [CustomRequired]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
    }
}
