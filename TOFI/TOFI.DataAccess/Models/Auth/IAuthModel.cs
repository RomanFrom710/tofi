using System;

namespace DAL.Models.Auth
{
    public interface IAuthModel : IModel
    {
        string PasswordHash { get; }

        int AccessFailedCnt { get; }

        DateTime? LockoutDateUtc { get; }

        int AccessGrantedTotal { get; }

        DateTime? LastAccessGrantedDateUtc { get; }

        int AccessFailedTotal { get; }

        DateTime? LastAccessFailedDateUtc { get; }
    }
}