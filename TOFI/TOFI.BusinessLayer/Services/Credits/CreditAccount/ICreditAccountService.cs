using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Credits.CreditAccountState.ViewModels;
using BLL.Services.Credits.CreditPayment.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Credits.CreditAccount.Commands;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.Queries;
using TOFI.TransferObjects.Credits.CreditAccountState.DataObjects;
using TOFI.TransferObjects.Credits.CreditPayment.DataObjects;

namespace BLL.Services.Credits.CreditAccount
{
    public interface ICreditAccountService : IModelService<CreditAccountDto, CreditAccountViewModel>
    {
        ListQueryResult<CreditPaymentDto> GetPaymentDtos(CreditPaymentsQuery query);

        Task<ListQueryResult<CreditPaymentDto>> GetPaymentDtosAsync(CreditPaymentsQuery query);

        ListQueryResult<CreditPaymentViewModel> GetPayments(CreditPaymentsQuery query);

        Task<ListQueryResult<CreditPaymentViewModel>> GetPaymentsAsync(CreditPaymentsQuery query);

        ListQueryResult<CreditAccountStateDto> GetAccountStateDtos(CreditAccountStatesQuery query);

        Task<ListQueryResult<CreditAccountStateDto>> GetAccountStateDtosAsync(CreditAccountStatesQuery query);

        ListQueryResult<CreditAccountStateViewModel> GetAccountStates(CreditAccountStatesQuery query);

        Task<ListQueryResult<CreditAccountStateViewModel>> GetAccountStatesAsync(CreditAccountStatesQuery query);

        QueryResult<CreditAccountStateDto> GetActualAccountStateDto(ActualCreditAccountStateQuery query);

        Task<QueryResult<CreditAccountStateDto>> GetActualAccountStateDtoAsync(ActualCreditAccountStateQuery query);

        QueryResult<CreditAccountStateViewModel> GetActualAccountState(ActualCreditAccountStateQuery query);

        Task<QueryResult<CreditAccountStateViewModel>> GetActualAccountStateAsync(ActualCreditAccountStateQuery query);


        CommandResult OpenCreditAccount(OpenAccountCommand command);

        Task<CommandResult> OpenCreditAccountAsync(OpenAccountCommand command);
    }
}