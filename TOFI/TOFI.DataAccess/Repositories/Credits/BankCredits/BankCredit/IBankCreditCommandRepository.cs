using DAL.Repositories.Model;
using DAL.Repositories.User;
using TOFI.TransferObjects.Credits.BankCredits.BankCredit.DataObjects;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Credits.BankCredits.BankCredit
{
    public interface IBankCreditCommandRepository : IModelCommandRepository<BankCreditDTO>
    {
    }
}