using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Contexts;
using DAL.Models.Credits.CreditAccount;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.Queries;
using TOFI.TransferObjects.Credits.CreditPayment.DataObjects;

namespace DAL.Repositories.Credits.CreditAccount
{
    public class CreditAccountStateQueryRepository : ModelQueryRepository<CreditAccountStateModel, CreditAccountStateDto>, ICreditAccountStateQueryRepository
    {
        public CreditAccountStateQueryRepository(TofiContext context) : base(context)
        {
        }
        
    }
}