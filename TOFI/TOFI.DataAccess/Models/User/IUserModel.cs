using DAL.Models.Auth;

namespace DAL.Models.User
{
    public interface IUserModel : IModel
    {
        string FirstName { get; }

        string LastName { get; }

        string MiddleName { get; }

        bool EmailConfirmed { get; }

        int AuthId { get; }

        AuthModel Auth { get; }
    }
}