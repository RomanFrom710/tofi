using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Credits.BankCredits.CreditRequirements
{
    public interface ICreditRequirementModel: IModel
    {
        string Description { get; set; }

        string ExpectedValue { get; set; }
    }
}
