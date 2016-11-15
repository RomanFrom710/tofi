using System;

namespace DAL.Models.User
{
    public interface IUserModel : IModel
    {
        string Username { get; }

        string Email { get; }

        string PasswordHash { get; }

        string FirstName { get; }

        string LastName { get; }

        string MiddleName { get; }

        bool EmailConfirmed { get; }

        int AccessGrantedTotal { get; }

        DateTime? LastAccessGrantedDateUtc { get; }

        int AccessFailedTotal { get; }

        DateTime? LastAccessFailedDateUtc { get; }

        int AccessFailedCnt { get; }

        DateTime? LockoutDateUtc { get; }
    }
}