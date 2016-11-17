using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.User;

namespace DAL.Models.Employee
{
    [Table("Employees")]
    public class EmployeeModel : UserModel, IEmployeeModel
    {
    }
}