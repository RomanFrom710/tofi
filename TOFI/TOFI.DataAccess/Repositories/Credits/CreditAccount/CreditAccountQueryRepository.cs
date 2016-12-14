using DAL.Contexts;
using DAL.Models.Credits;
using DAL.Models.Credits.BankCredits;
using DAL.Models.Employee;
using DAL.Repositories.Model;
using DAL.Repositories.User;
using TOFI.TransferObjects.Credits.BankCredit.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Credits.CreditAccount
{
    public class CreditAccountQueryRepository : ModelQueryRepository<CreditAccountModel, CreditAccountDTO>, ICreditAccountQueryRepository
    {
        public CreditAccountQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}