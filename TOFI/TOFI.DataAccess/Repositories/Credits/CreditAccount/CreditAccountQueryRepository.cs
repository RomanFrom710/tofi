using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Contexts;
using DAL.Models.Credits.CreditAccount;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.Queries;
using TOFI.TransferObjects.Credits.CreditAccountState.DataObjects;
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
            return creditAccount?.Payments.MapTo<CreditPaymentDto>() ?? Enumerable.Empty<CreditPaymentDto>();
        }

        public async Task<IEnumerable<CreditPaymentDto>> HandleAsync(CreditPaymentsQuery query)
        {
            var creditAccount = await ModelsDao.FindAsync(query.CreditAccountId);
            return creditAccount?.Payments.MapTo<CreditPaymentDto>() ?? Enumerable.Empty<CreditPaymentDto>();
        }

        public IEnumerable<CreditAccountStateDto> Handle(CreditAccountStatesQuery query)
        {
            var creditAccount = ModelsDao.Find(query.CreditAccountId);
            return creditAccount?.CreditAccountStates.MapTo<CreditAccountStateDto>() ??
                   Enumerable.Empty<CreditAccountStateDto>();
        }

        public async Task<IEnumerable<CreditAccountStateDto>> HandleAsync(CreditAccountStatesQuery query)
        {
            var creditAccount = await ModelsDao.FindAsync(query.CreditAccountId);
            return creditAccount?.CreditAccountStates.MapTo<CreditAccountStateDto>() ??
                   Enumerable.Empty<CreditAccountStateDto>();
        }

        public CreditAccountStateDto Handle(ActualCreditAccountStateQuery query)
        {
            var creditAccount = ModelsDao.Find(query.CreditAccountId);
            if (creditAccount == null)
            {
                return null;
            }
            var creditAccountStatesQuery = new CreditAccountStatesQuery {CreditAccountId = creditAccount.Id};
            var latestCreditAccountState = Handle(creditAccountStatesQuery);
            return latestCreditAccountState.OrderBy(s => s.Month).LastOrDefault();
        }

        public async Task<CreditAccountStateDto> HandleAsync(ActualCreditAccountStateQuery query)
        {
            var creditAccount = await ModelsDao.FindAsync(query.CreditAccountId);
            if (creditAccount == null)
            {
                return null;
            }
            var creditAccountStatesQuery = new CreditAccountStatesQuery {CreditAccountId = creditAccount.Id};
            var latestCreditAccountState = await HandleAsync(creditAccountStatesQuery);
            return latestCreditAccountState.OrderBy(s => s.Month).LastOrDefault();
        }
    }
}