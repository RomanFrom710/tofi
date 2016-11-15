using DAL.Models.Auth;

namespace DAL.Models.User
{
    public abstract class UserModel : AuthModel, IUserModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public bool EmailConfirmed { get; set; }


        protected UserModel()
        {
            EmailConfirmed = false;
        }
    }
}