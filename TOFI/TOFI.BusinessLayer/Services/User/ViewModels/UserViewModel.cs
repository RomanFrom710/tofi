using BLL.Services.Model.ViewModels;

namespace BLL.Services.User.ViewModels
{
    public class UserViewModel : ModelViewModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}