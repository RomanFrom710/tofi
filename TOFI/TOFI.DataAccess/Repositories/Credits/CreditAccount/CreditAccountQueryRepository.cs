using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
            CreditAccountModel creditAccount = null;
            if (query.Id.HasValue)
            {
                creditAccount = ModelsDao.Find(query.Id.Value);
            }
            if (!string.IsNullOrEmpty(query.AgreementNumber))
            {
                creditAccount = ModelsDao.FirstOrDefault(u => u.CreditAgreementNumber == query.AgreementNumber);
            }
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
            CreditAccountModel creditAccount = null;
            if (query.Id.HasValue)
            {
                creditAccount = await ModelsDao.FindAsync(query.Id.Value);
            }
            if (!string.IsNullOrEmpty(query.AgreementNumber))
            {
                creditAccount = await ModelsDao.FirstOrDefaultAsync(u => u.CreditAgreementNumber == query.AgreementNumber);
            }
            if (creditAccount == null)
            {
                return null;
            }
            var creditAccountStatesQuery = new CreditAccountStatesQuery { CreditAccountId = creditAccount.Id };
            var latestCreditAccountState = await HandleAsync(creditAccountStatesQuery);
            return latestCreditAccountState.OrderBy(s => s.Month).LastOrDefault();
        }

        public CreditAccountDto Handle(CreditAccountQuery query)
        {
            CreditAccountModel model = null;
            if (query.Id.HasValue)
            {
                model = ModelsDao.Find(query.Id.Value);
            }
            if (!string.IsNullOrEmpty(query.AgreementNumber))
            {
                model = ModelsDao.FirstOrDefault(u => u.CreditAgreementNumber == query.AgreementNumber);
            }
            return model == null ? null : Mapper.Map<CreditAccountDto>(model);
        }

        public async Task<CreditAccountDto> HandleAsync(CreditAccountQuery query)
        {
            CreditAccountModel model = null;
            if (query.Id.HasValue)
            {
                model = await ModelsDao.FindAsync(query.Id.Value);
            }
            if (!string.IsNullOrEmpty(query.AgreementNumber))
            {
                model = await ModelsDao.FirstOrDefaultAsync(u => u.CreditAgreementNumber == query.AgreementNumber);
            }
            return model == null ? null : Mapper.Map<CreditAccountDto>(model);
        }
    }
}