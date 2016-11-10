using System;

namespace DAL.Models.User
{
    public abstract class UserModel : Model, IUserModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool EmailConfirmed { get; set; }

        public int SuccessfulLogonAttempts { get; set; }

        public int FailedLogonAttempts { get; set; }

        public int FailedLogonCnt { get; set; }

        public DateTime NextLogonTime { get; set; }


        protected UserModel()
        {
            EmailConfirmed = false;
            SuccessfulLogonAttempts = 0;
            FailedLogonAttempts = 0;
            FailedLogonCnt = 0;
            NextLogonTime = DateTime.MinValue;
        }
    }
}