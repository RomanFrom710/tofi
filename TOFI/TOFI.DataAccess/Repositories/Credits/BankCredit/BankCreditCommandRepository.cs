using DAL.Contexts;
using DAL.Models.Credits.BankCredits;
using DAL.Models.Employee;
using DAL.Repositories.Model;
using DAL.Repositories.User;
using TOFI.TransferObjects.Credits.BankCredit.DataObjects;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Credits.BankCredit
{
    public class BankCreditCommandRepository : ModelCommandRepository<BankCreditModel, BankCreditDTO>, IBankCreditCommandRepository
    {
        public BankCreditCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}