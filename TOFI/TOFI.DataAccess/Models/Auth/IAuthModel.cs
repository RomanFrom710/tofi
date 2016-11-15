using System;

namespace DAL.Models.Auth
{
    public interface IAuthModel : IModel
    {
        string Username { get; }

        string Email { get; }

        string PasswordHash { get; }

        int AccessGrantedTotal { get; }

        DateTime? LastAccessGrantedDateUtc { get; }

        int AccessFailedTotal { get; }

        DateTime? LastAccessFailedDateUtc { get; }

        int AccessFailedCnt { get; }

        DateTime? LockoutDateUtc { get; }
    }
}