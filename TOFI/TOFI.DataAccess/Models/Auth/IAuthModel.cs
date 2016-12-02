using System;

namespace DAL.Models.Auth
{
    public interface IAuthModel : IModel
    {
        string PasswordHash { get; }

        string Salt { get; }

        string SecurityStamp { get; }

        bool LockoutEnabled { get; }

        int AccessFailedCnt { get; }

        DateTimeOffset? LockoutDateUtc { get; }

        int AccessGrantedTotal { get; }

        DateTimeOffset? LastAccessGrantedDateUtc { get; }

        int AccessFailedTotal { get; }

        DateTimeOffset? LastAccessFailedDateUtc { get; }
    }
}