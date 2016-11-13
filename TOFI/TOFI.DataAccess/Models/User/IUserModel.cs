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

        bool EmailConfirmed { get; }

        int SuccessfulLogonAttempts { get; }

        int FailedLogonAttempts { get; }

        int FailedLogonCnt { get; }

        DateTime? NextLogonTime { get; }
    }
}