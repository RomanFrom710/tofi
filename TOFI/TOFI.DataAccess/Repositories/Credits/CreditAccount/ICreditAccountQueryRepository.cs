using DAL.Repositories.Model;
using DAL.Repositories.User;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Employee.DataObjects;

namespace DAL.Repositories.Credits.CreditAccount
{
    public interface ICreditAccountQueryRepository : IModelQueryRepository<CreditAccountDTO>
    {
    }
}