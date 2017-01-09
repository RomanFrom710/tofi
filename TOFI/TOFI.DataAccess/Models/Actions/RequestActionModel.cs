using DAL.Models.Credits.CreditRequest;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;

namespace DAL.Models.Actions
{
    [Table("RequestActions")]
    public class RequestActionModel : ActionModel
    {
        #region Virtual Properties

        [IgnoreMap]
        public virtual CreditRequestModel CreditRequest { get; set; }

        #endregion
    }
}