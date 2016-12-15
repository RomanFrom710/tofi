using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Credits.BankCredits.CreditRequirements
{
    [Table("CreditRequirements")]
    public class CreditRequirementModel : Model, ICreditRequirementModel
    {
        public string Description { get; set; }

        public string ExpectedValue { get; set; }
    }
}
