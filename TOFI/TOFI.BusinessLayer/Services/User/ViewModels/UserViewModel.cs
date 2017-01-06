using System.Linq;
using AutoMapper;
using BLL.Services.Auth.ViewModels;
using BLL.Services.Model.ViewModels;

namespace BLL.Services.User.ViewModels
{
    public class UserViewModel : ModelViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Key { get; set; }

        public AuthViewModel Auth { get; set; }

        [IgnoreMap]
        public string FullName
        {
            get
            {
                var parts = new[] { LastName, FirstName, MiddleName };
                var res = string.Join(" ", parts.Where(i => !string.IsNullOrWhiteSpace(i)));
                return string.IsNullOrWhiteSpace(res) ? "<Имя не указано>" : res;
            }
        }
    }
}