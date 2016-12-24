using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Credits.BankCredits.CreditTypes;

namespace DAL.Models.Credits.BankCredits.CreditRequirements
{
    [Table("CreditRequirements")]
    public class CreditRequirementModel : Model
    {
        public string Description { get; set; }

        public string ExpectedValue { get; set; }

        #region Virtual Properties

        public virtual CreditTypeModel CreditType { get; set; }

        #endregion
    }
}