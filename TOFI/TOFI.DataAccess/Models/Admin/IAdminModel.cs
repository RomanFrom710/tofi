using DAL.Models.User;

namespace DAL.Models.Admin
{
    public interface IAdminModel : IModel
    {
        int UserId { get; }

        UserModel User { get; }
    }
}