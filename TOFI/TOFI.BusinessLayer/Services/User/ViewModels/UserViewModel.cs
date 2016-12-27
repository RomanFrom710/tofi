using BLL.Services.Auth.ViewModels;
using BLL.Services.Client.ViewModels;
using BLL.Services.Employee.ViewModels;
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

        public ClientViewModel Client { get; set; }

        public EmployeeViewModel Employee { get; set; }
    }
}