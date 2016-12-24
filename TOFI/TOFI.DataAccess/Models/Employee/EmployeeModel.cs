using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.User;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Models.Employee
{
    [Table("Employees")]
    public class EmployeeModel : Model
    {
        public EmployeeRights Rights { get; set; }

        #region Virtual Properties

        public virtual UserModel User { get; set; }

        #endregion
    }
}