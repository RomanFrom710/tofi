using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Auth
{
    [Table("Auth")]
    public class AuthModel : Model, IAuthModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public int AccessGrantedTotal { get; set; }

        public DateTime? LastAccessGrantedDateUtc { get; set; }

        public int AccessFailedTotal { get; set; }

        public DateTime? LastAccessFailedDateUtc { get; set; }

        public int AccessFailedCnt { get; set; }

        public DateTime? LockoutDateUtc { get; set; }


        protected AuthModel()
        {
            AccessGrantedTotal = 0;
            LastAccessGrantedDateUtc = null;
            AccessFailedTotal = 0;
            LastAccessFailedDateUtc = null;
            AccessFailedCnt = 0;
            LockoutDateUtc = null;
        }
    }
}