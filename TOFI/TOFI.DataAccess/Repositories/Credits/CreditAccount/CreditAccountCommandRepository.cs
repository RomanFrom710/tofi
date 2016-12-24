using DAL.Contexts;
using DAL.Models.Credits.CreditAccount;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;

namespace DAL.Repositories.Credits.CreditAccount
{
    public class CreditAccountCommandRepository : ModelCommandRepository<CreditAccountModel, CreditAccountDTO>, ICreditAccountCommandRepository
    {
        public CreditAccountCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}