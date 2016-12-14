using DAL.Repositories.Model;
using DAL.Repositories.User;
using TOFI.TransferObjects.Credits.BankCredit.DataObjects;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Credits.BankCredit
{
    public interface IBankCreditCommandRepository : IModelCommandRepository<BankCreditDTO>
    {
    }
}