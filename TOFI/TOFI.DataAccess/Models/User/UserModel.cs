using System;

namespace DAL.Models.User
{
    public abstract class UserModel : Model, IUserModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public bool EmailConfirmed { get; set; }

        public int AccessGrantedTotal { get; set; }

        public DateTime? LastAccessGrantedDateUtc { get; set; }

        public int AccessFailedTotal { get; set; }

        public DateTime? LastAccessFailedDateUtc { get; set; }

        public int AccessFailedCnt { get; set; }

        public DateTime? LockoutDateUtc { get; set; }


        protected UserModel()
        {
            EmailConfirmed = false;
            AccessGrantedTotal = 0;
            LastAccessGrantedDateUtc = null;
            AccessFailedTotal = 0;
            LastAccessFailedDateUtc = null;
            AccessFailedCnt = 0;
            LockoutDateUtc = null;
        }
    }
}