using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Credits.CreditPayment.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.CreditAccount;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.Queries;
using TOFI.TransferObjects.Credits.CreditPayment.DataObjects;

namespace BLL.Services.Credits.CreditAccount
{
    public class CreditAccountService : ModelService<CreditAccountDto, CreditAccountViewModel>, ICreditAccountService
    {
        private readonly ICreditAccountQueryRepository _queryRepository;
        private readonly ICreditAccountCommandRepository _commandRepository;


        public CreditAccountService(ICreditAccountQueryRepository queryRepository,
            ICreditAccountCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }


        public ListQueryResult<CreditPaymentDto> GetPaymentDtos(CreditPaymentsQuery query)
        {
            return RunListQuery<CreditPaymentsQuery, CreditPaymentDto>(_queryRepository, query);
        }

        public async Task<ListQueryResult<CreditPaymentDto>> GetPaymentDtosAsync(CreditPaymentsQuery query)
        {
            return await RunListQueryAsync<CreditPaymentsQuery, CreditPaymentDto>(_queryRepository, query);
        }

        public ListQueryResult<CreditPaymentViewModel> GetPayments(CreditPaymentsQuery query)
        {
            return RunListQuery<CreditPaymentsQuery, CreditPaymentDto>(_queryRepository, query)
                .MapTo<CreditPaymentViewModel>();
        }

        public async Task<ListQueryResult<CreditPaymentViewModel>> GetPaymentsAsync(CreditPaymentsQuery query)
        {
            return (await RunListQueryAsync<CreditPaymentsQuery, CreditPaymentDto>(_queryRepository, query))
                .MapTo<CreditPaymentViewModel>();
        }
    }
}