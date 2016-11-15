using System;
using TOFI.TransferObjects.Model.DataObjects;

namespace TOFI.TransferObjects.Auth.DataObjects
{
    public class LoginDto : ModelDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public int AccessFailedCnt { get; set; }

        public DateTime? LockoutDateUtc { get; set; }
    }
}