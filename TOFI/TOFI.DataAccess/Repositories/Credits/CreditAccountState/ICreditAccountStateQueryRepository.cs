using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditAccountState.DataObjects;

namespace DAL.Repositories.Credits.CreditAccountState
{
    public interface ICreditAccountStateQueryRepository : IModelQueryRepository<CreditAccountStateDto>
    {
    }
}