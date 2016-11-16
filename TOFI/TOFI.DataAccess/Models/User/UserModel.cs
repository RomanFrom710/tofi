using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Auth;

namespace DAL.Models.User
{
    [Table("Users")]
    public class UserModel : Model, IUserModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public bool EmailConfirmed { get; set; }

        public int AuthId { get; set; }

        public virtual AuthModel Auth { get; set; }


        public UserModel()
        {
            EmailConfirmed = false;
        }
    }
}