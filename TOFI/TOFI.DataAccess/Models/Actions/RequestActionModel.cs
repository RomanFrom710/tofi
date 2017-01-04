using DAL.Models.Credits.CreditRequest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Actions
{
    [Table("RequestActions")]
    public class RequestActionModel: ActionModel
    {

        #region Virtual Properties

        public virtual CreditRequestModel CreditRequest { get; set; }

        #endregion
    }
}
