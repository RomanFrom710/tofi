using DAL.Contexts;
using DAL.Models.Credits.CreditAccount;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditAccountState.DataObjects;

namespace DAL.Repositories.Credits.CreditAccountState
{
    public class CreditAccountStateQueryRepository : ModelQueryRepository<CreditAccountStateModel, CreditAccountStateDto>, ICreditAccountStateQueryRepository
    {
        public CreditAccountStateQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}