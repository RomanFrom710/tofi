using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Credits.CreditAccountState.ViewModels;
using BLL.Services.Credits.CreditPayment.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.CreditAccount;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.Queries;
using TOFI.TransferObjects.Credits.CreditAccountState.DataObjects;
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

        public ListQueryResult<CreditAccountStateDto> GetAccountStateDtos(CreditAccountStatesQuery query)
        {
            return RunListQuery<CreditAccountStatesQuery, CreditAccountStateDto>(_queryRepository, query);
        }

        public async Task<ListQueryResult<CreditAccountStateDto>> GetAccountStateDtosAsync(CreditAccountStatesQuery query)
        {
            return await RunListQueryAsync<CreditAccountStatesQuery, CreditAccountStateDto>(_queryRepository, query);
        }

        public ListQueryResult<CreditAccountStateViewModel> GetAccountStates(CreditAccountStatesQuery query)
        {
            return RunListQuery<CreditAccountStatesQuery, CreditAccountStateDto>(_queryRepository, query)
                .MapTo<CreditAccountStateViewModel>();
        }

        public async Task<ListQueryResult<CreditAccountStateViewModel>> GetAccountStatesAsync(CreditAccountStatesQuery query)
        {
            return (await RunListQueryAsync<CreditAccountStatesQuery, CreditAccountStateDto>(_queryRepository, query))
                .MapTo<CreditAccountStateViewModel>();
        }

        public QueryResult<CreditAccountStateDto> GetActualAccountStateDto(ActualCreditAccountStateQuery query)
        {
            return RunQuery<ActualCreditAccountStateQuery, CreditAccountStateDto>(_queryRepository, query);
        }

        public async Task<QueryResult<CreditAccountStateDto>> GetActualAccountStateDtoAsync(ActualCreditAccountStateQuery query)
        {
            return await RunQueryAsync<ActualCreditAccountStateQuery, CreditAccountStateDto>(_queryRepository, query);
        }

        public QueryResult<CreditAccountStateViewModel> GetActualAccountState(ActualCreditAccountStateQuery query)
        {
            return RunQuery<ActualCreditAccountStateQuery, CreditAccountStateDto>(_queryRepository, query)
                .MapTo<CreditAccountStateViewModel>();
        }

        public async Task<QueryResult<CreditAccountStateViewModel>> GetActualAccountStateAsync(ActualCreditAccountStateQuery query)
        {
            return (await RunQueryAsync<ActualCreditAccountStateQuery, CreditAccountStateDto>(_queryRepository, query))
                .MapTo<CreditAccountStateViewModel>();
        }
    }
}