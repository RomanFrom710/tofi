using DAL.Models.Employee;
using DAL.Models.User;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Actions
{
    [Table("Actions")]
    public class ActionModel : Model
    {
        public string Signature { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }

        public string Data { get; set; }

        #region Virtual Properties

        public virtual EmployeeModel Employee { get; set; }

        #endregion
    }
}
