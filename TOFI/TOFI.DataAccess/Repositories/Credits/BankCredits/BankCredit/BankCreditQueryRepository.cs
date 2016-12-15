using DAL.Contexts;
using DAL.Models.Credits.BankCredits;
using DAL.Models.Employee;
using DAL.Repositories.Model;
using DAL.Repositories.User;
using TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.BankCredit
{
    public class BankCreditQueryRepository : ModelQueryRepository<BankCreditModel, BankCreditDTO>, IBankCreditQueryRepository
    {
        public BankCreditQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}