using DAL.Models.Auth;

namespace DAL.Models.User
{
    public interface IUserModel : IModel
    {
        string Username { get; }

        string Email { get; }

        bool EmailConfirmed { get; }

        string FirstName { get; }

        string LastName { get; }

        string MiddleName { get; }
        
        int AuthId { get; }

        AuthModel Auth { get; }
    }
}