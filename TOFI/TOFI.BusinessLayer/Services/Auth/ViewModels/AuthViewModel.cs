using BLL.Services.Model.ViewModels;

namespace BLL.Services.Auth.ViewModels
{
    public class AuthViewModel : ModelViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }
    }
}