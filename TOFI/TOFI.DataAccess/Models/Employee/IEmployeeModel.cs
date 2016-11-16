using DAL.Models.User;

namespace DAL.Models.Employee
{
    public interface IEmployeeModel : IModel
    {
        int UserId { get; }

        UserModel User { get; }
    }
}