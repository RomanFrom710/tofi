using DAL.Contexts;
using DAL.Models.Credits.BankCredits.BankCredit;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.BankCredit
{
    public class BankCreditQueryRepository : ModelQueryRepository<BankCreditModel, BankCreditDto>, IBankCreditQueryRepository
    {
        public BankCreditQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}