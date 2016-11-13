using System;

namespace TOFI.TransferObjects.User.DataObjects
{
    public class LoginDto : Dto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public int FailedLogonCnt { get; set; }

        public DateTime? NextLogonTime { get; set; }
    }
}