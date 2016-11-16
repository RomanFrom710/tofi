using BLL.Services.Auth.ViewModels;

namespace BLL.Services.User.ViewModels
{
    public class UserViewModel : AuthViewModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}