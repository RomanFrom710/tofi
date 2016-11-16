using DAL.Models.User;

namespace DAL.Models.Client
{
    public interface IClientModel : IModel
    {
        int UserId { get; }

        UserModel User { get; }
    }
}