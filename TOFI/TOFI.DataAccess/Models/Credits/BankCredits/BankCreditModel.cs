using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Models.Common;

namespace DAL.Models.Credits.BankCredits
{
    [Table("BankCredits")]
    public class BankCreditModel : Model, IBankCreditModel
    {
        public string Description { get; set; }

        public double InterestRate { get; set; }

        public int MonthDuration { get; set; }

        public virtual PriceModel Sum { get; set; }
    }
}
