using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.User;

namespace DAL.Models.Client
{
    [Table("Clients")]
    public class ClientModel : Model, IClientModel
    {
        public int UserId { get; set; }

        public virtual UserModel User { get; set; }
    }
}