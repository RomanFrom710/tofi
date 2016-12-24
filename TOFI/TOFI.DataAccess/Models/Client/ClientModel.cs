using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.User;

namespace DAL.Models.Client
{
    [Table("Clients")]
    public class ClientModel : UserModel
    {
    }
}