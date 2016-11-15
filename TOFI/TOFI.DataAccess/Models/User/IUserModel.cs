using DAL.Models.Auth;

namespace DAL.Models.User
{
    public interface IUserModel : IAuthModel
    {
        string FirstName { get; }

        string LastName { get; }

        string MiddleName { get; }

        bool EmailConfirmed { get; }
    }
}