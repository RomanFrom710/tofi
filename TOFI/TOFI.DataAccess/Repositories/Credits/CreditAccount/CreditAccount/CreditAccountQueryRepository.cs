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
    public class CreditAccountQueryRepository : ModelQueryRepository<CreditAccountModel, CreditAccountDto>, ICreditAccountQueryRepository
    {
        public CreditAccountQueryRepository(TofiContext context) : base(context)
        {
        }


        public IEnumerable<CreditPaymentDto> Handle(CreditPaymentsQuery query)
        {
            var creditAccount = ModelsDao.Find(query.CreditAccountId);
            if (creditAccount == null)
                return Enumerable.Empty<CreditPaymentDto>();
            return creditAccount.Payments.MapTo<CreditPaymentDto>();
        }

        public async Task<IEnumerable<CreditPaymentDto>> HandleAsync(CreditPaymentsQuery query)
        {
            var creditAccount = await ModelsDao.FindAsync(query.CreditAccountId);
            if (creditAccount == null)
                return Enumerable.Empty<CreditPaymentDto>();
            return creditAccount.Payments.MapTo<CreditPaymentDto>();
        }
    }
}