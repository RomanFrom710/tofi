using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Auth
{
    [Table("AuthData")]
    public class AuthModel : Model, IAuthModel
    {
        public string PasswordHash { get; set; }

        public string Salt { get; set; }

        public int AccessFailedCnt { get; set; }

        public DateTime? LockoutDateUtc { get; set; }

        public int AccessGrantedTotal { get; set; }

        public DateTime? LastAccessGrantedDateUtc { get; set; }

        public int AccessFailedTotal { get; set; }

        public DateTime? LastAccessFailedDateUtc { get; set; }
    }
}