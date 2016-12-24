using DAL.Contexts;
using DAL.Models.Credits.BankCredits.BankCredit;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.BankCredit
{
    public class BankCreditCommandRepository : ModelCommandRepository<BankCreditModel, BankCreditDto>, IBankCreditCommandRepository
    {
        public BankCreditCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}