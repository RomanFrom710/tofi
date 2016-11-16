using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.User;

namespace DAL.Models.Admin
{
    [Table("Admins")]
    public class AdminModel : Model, IAdminModel
    {
        public int UserId { get; set; }

        public virtual UserModel User { get; set; }
    }
}