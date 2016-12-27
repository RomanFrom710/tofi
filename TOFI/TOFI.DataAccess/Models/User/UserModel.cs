using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Auth;
using System.Collections.Generic;
using DAL.Models.Client;
using DAL.Models.Credits.CreditAccount;
using DAL.Models.Employee;

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

        public string Key { get; set; }

        #region Virtual Properties

        public virtual AuthModel Auth { get; set; }

        public virtual ClientModel Client { get; set; }

        public virtual EmployeeModel Employee { get; set; }

        public virtual ICollection<CreditAccountModel> CreditAccounts { get; set; }

        public virtual ICollection<UserActionModel> Actions { get; set; }

        #endregion
    }
}