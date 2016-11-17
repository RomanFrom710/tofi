using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.User;

namespace DAL.Models.Admin
{
    [Table("Admins")]
    public class AdminModel : UserModel, IAdminModel
    {
    }
}