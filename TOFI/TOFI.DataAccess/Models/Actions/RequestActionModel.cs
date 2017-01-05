using DAL.Models.Credits.CreditRequest;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models.Actions
{
    [Table("RequestActions")]
    public class RequestActionModel : ActionModel
    {
        #region Virtual Properties

        public virtual CreditRequestModel CreditRequest { get; set; }

        #endregion
    }
}