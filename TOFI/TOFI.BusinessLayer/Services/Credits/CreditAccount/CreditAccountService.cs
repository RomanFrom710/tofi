using System;
using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Credits.CreditAccountState;
using BLL.Services.Credits.CreditAccountState.ViewModels;
using BLL.Services.Credits.CreditPayment.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.CreditAccount;
using TOFI.TransferObjects.Common.Price.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.Commands;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.Queries;
using TOFI.TransferObjects.Credits.CreditAccountState.DataObjects;
using TOFI.TransferObjects.Credits.CreditPayment.DataObjects;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;

namespace BLL.Services.Credits.CreditAccount
{
    public class CreditAccountService : ModelService<CreditAccountDto, CreditAccountViewModel>, ICreditAccountService
    {
        private readonly ICreditAccountQueryRepository _queryRepository;
        private readonly ICreditAccountCommandRepository _commandRepository;
        private readonly ICreditAccountStateService _accountStateService;


        public CreditAccountService(ICreditAccountQueryRepository queryRepository,
            ICreditAccountCommandRepository commandRepository, ICreditAccountStateService accountStateService)
            : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _accountStateService = accountStateService;
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

        public async Task<ListQueryResult<CreditAccountStateDto>> GetAccountStateDtosAsync(
            CreditAccountStatesQuery query)
        {
            return await RunListQueryAsync<CreditAccountStatesQuery, CreditAccountStateDto>(_queryRepository, query);
        }

        public ListQueryResult<CreditAccountStateViewModel> GetAccountStates(CreditAccountStatesQuery query)
        {
            return RunListQuery<CreditAccountStatesQuery, CreditAccountStateDto>(_queryRepository, query)
                .MapTo<CreditAccountStateViewModel>();
        }

        public async Task<ListQueryResult<CreditAccountStateViewModel>> GetAccountStatesAsync(
            CreditAccountStatesQuery query)
        {
            return (await RunListQueryAsync<CreditAccountStatesQuery, CreditAccountStateDto>(_queryRepository, query))
                .MapTo<CreditAccountStateViewModel>();
        }

        public QueryResult<CreditAccountStateDto> GetActualAccountStateDto(ActualCreditAccountStateQuery query)
        {
            return RunQuery<ActualCreditAccountStateQuery, CreditAccountStateDto>(_queryRepository, query);
        }

        public async Task<QueryResult<CreditAccountStateDto>> GetActualAccountStateDtoAsync(
            ActualCreditAccountStateQuery query)
        {
            return await RunQueryAsync<ActualCreditAccountStateQuery, CreditAccountStateDto>(_queryRepository, query);
        }

        public QueryResult<CreditAccountStateViewModel> GetActualAccountState(ActualCreditAccountStateQuery query)
        {
            return RunQuery<ActualCreditAccountStateQuery, CreditAccountStateDto>(_queryRepository, query)
                .MapTo<CreditAccountStateViewModel>();
        }

        public async Task<QueryResult<CreditAccountStateViewModel>> GetActualAccountStateAsync(
            ActualCreditAccountStateQuery query)
        {
            return (await RunQueryAsync<ActualCreditAccountStateQuery, CreditAccountStateDto>(_queryRepository, query))
                .MapTo<CreditAccountStateViewModel>();
        }


        public CommandResult OpenCreditAccount(OpenAccountCommand command)
        {
            try
            {
                var account = FillAccount(command.Request);
                var res = CreateModel(account);
                if (res.IsFailed)
                {
                    return new CommandResult(command, false).From(res);
                }
                var accountState = FillAccountState(command.Request, account);
                res = _accountStateService.CreateModel(accountState);
                if (res.IsFailed)
                {
                    return new CommandResult(command, false).From(res);
                }
                return new CommandResult(command, true);
            }
            catch (Exception ex)
            {
                return new CommandResult(command, false).Fatal($"Unhandled exception: {ex.Message}", ex);
            }
        }

        public async Task<CommandResult> OpenCreditAccountAsync(OpenAccountCommand command)
        {
            try
            {
                var account = FillAccount(command.Request);
                var res = await CreateModelAsync(account);
                if (res.IsFailed)
                {
                    return new CommandResult(command, false).From(res);
                }
                var accountState = FillAccountState(command.Request, account);
                res = await _accountStateService.CreateModelAsync(accountState);
                if (res.IsFailed)
                {
                    return new CommandResult(command, false).From(res);
                }
                return new CommandResult(command, true);
            }
            catch (Exception ex)
            {
                return new CommandResult(command, false).Fatal($"Unhandled exception: {ex.Message}", ex);
            }
        }


        private CreditAccountDto FillAccount(CreditRequestDto request)
        {
            return new CreditAccountDto
            {
                AgreementDate = DateTime.Now,
                CreditAgreementNumber = Guid.NewGuid().ToString(),
                CreditType = request.CreditType,
                TotalMonthDuration = request.MonthDuration,
                Client = request.Client,
                Currency = request.CreditSum.Currency,
                Description = request.CreditPurpose
            };
        }

        private CreditAccountStateDto FillAccountState(CreditRequestDto request, CreditAccountDto account)
        {
            return new CreditAccountStateDto
            {
                CreditAccount = account,
                Month = 0,
                InterestCounted = new PriceDto {Value = 0, Currency = account.Currency},
                FinesForOverdue = new PriceDto {Value = 0, Currency = account.Currency},
                TotalInterestSumNotPaid = new PriceDto {Value = 0, Currency = account.Currency},
                RemainDebt = request.CreditSum
            };
        }
    }
}