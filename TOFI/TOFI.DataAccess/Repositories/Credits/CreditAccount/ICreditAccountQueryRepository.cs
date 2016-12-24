using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;

namespace DAL.Repositories.Credits.CreditAccount
{
    public interface ICreditAccountQueryRepository : IModelQueryRepository<CreditAccountDTO>
    {
    }
}