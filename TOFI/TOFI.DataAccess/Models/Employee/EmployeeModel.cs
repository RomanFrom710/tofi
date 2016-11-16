using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.User;

namespace DAL.Models.Employee
{
    [Table("Employees")]
    public class EmployeeModel : Model, IEmployeeModel
    {
        public int UserId { get; set; }

        public virtual UserModel User { get; set; }
    }
}