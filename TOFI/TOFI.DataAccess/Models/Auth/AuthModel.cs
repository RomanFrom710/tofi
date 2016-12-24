using DAL.Models.User;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Auth
{
    [Table("AuthData")]
    public class AuthModel : Model
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

        #region Virtual Properties

        public virtual UserModel User { get; set; }

        #endregion

    }
}