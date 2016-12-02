using System;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Auth.DataObjects
{
    public class AuthDto : ModelDto
    {
        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public string SecurityStamp { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCnt { get; set; }

        public DateTimeOffset? LockoutDateUtc { get; set; }

        public int AccessGrantedTotal { get; set; }

        public DateTimeOffset? LastAccessGrantedDateUtc { get; set; }

        public int AccessFailedTotal { get; set; }

        public DateTimeOffset? LastAccessFailedDateUtc { get; set; }
    }
}