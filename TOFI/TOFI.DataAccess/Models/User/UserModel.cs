using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Auth;
using DAL.Models.Credits;
using System.Collections.Generic;

namespace DAL.Models.User
{
    [Table("Users")]
    public class UserModel : Model
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        #region Virtual Properties

        public virtual AuthModel Auth { get; set; }

        public virtual ICollection<CreditAccountModel> CreditAccounts { get; set; }

        #endregion

        public UserModel()
        {
            EmailConfirmed = false;
        }
    }
}