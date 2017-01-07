using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Credits.BankCredits.CreditTypes;
using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.CreditRequest;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;
using TOFI.TransferObjects.Credits.CreditRequest.Queries;
using TOFI.TransferObjects.Model.Queries;

namespace BLL.Services.Credits.CreditRequest
{
    public class CreditRequestService : ModelService<CreditRequestDto, CreditRequestViewModel>, ICreditRequestService
    {
        private readonly ICreditRequestQueryRepository _queryRepository;
        private readonly ICreditRequestCommandRepository _commandRepository;
        private readonly ICreditTypeService _creditTypeQueryRepository;


        public CreditRequestService(ICreditRequestQueryRepository queryRepository,
            ICreditRequestCommandRepository commandRepository, ICreditTypeService creditTypeQueryRepository)
            : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _creditTypeQueryRepository = creditTypeQueryRepository;
        }


        public ListQueryResult<CreditRequestDto> GetClientRequestsDtos(ClientRequestsQuery query)
        {
            return RunListQuery<ClientRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetClientRequestsDtosAsync(ClientRequestsQuery query)
        {
            return await RunListQueryAsync<ClientRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public ListQueryResult<CreditRequestViewModel> GetClientRequests(ClientRequestsQuery query)
        {
            return RunListQuery<ClientRequestsQuery, CreditRequestDto>(_queryRepository, query)
                .MapTo<CreditRequestViewModel>();
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetClientRequestsAsync(ClientRequestsQuery query)
        {
            return (await RunListQueryAsync<ClientRequestsQuery, CreditRequestDto>(_queryRepository, query))
                .MapTo<CreditRequestViewModel>();
        }

        public ListQueryResult<CreditRequestDto> GetOperatorRequestsDtos(OperatorRequestsQuery query)
        {
            return RunListQuery<OperatorRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetOperatorRequestsDtosAsync(OperatorRequestsQuery query)
        {
            return await RunListQueryAsync<OperatorRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public ListQueryResult<CreditRequestViewModel> GetOperatorRequests(OperatorRequestsQuery query)
        {
            return RunListQuery<OperatorRequestsQuery, CreditRequestDto>(_queryRepository, query)
                .MapTo<CreditRequestViewModel>();
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetOperatorRequestsAsync(OperatorRequestsQuery query)
        {
            return (await RunListQueryAsync<OperatorRequestsQuery, CreditRequestDto>(_queryRepository, query))
                .MapTo<CreditRequestViewModel>();
        }

        public ListQueryResult<CreditRequestDto> GetSecurityRequestsDtos(SecurityRequestsQuery query)
        {
            return RunListQuery<SecurityRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetSecurityRequestsDtosAsync(SecurityRequestsQuery query)
        {
            return await RunListQueryAsync<SecurityRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public ListQueryResult<CreditRequestViewModel> GetSecurityRequests(SecurityRequestsQuery query)
        {
            return RunListQuery<SecurityRequestsQuery, CreditRequestDto>(_queryRepository, query)
                .MapTo<CreditRequestViewModel>();
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetSecurityRequestsAsync(SecurityRequestsQuery query)
        {
            return (await RunListQueryAsync<SecurityRequestsQuery, CreditRequestDto>(_queryRepository, query))
                .MapTo<CreditRequestViewModel>();
        }

        public ListQueryResult<CreditRequestDto> GetCommiteeRequestsDtos(CommiteeRequestsQuery query)
        {
            return RunListQuery<CommiteeRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetCommiteeRequestsDtosAsync(CommiteeRequestsQuery query)
        {
            return await RunListQueryAsync<CommiteeRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public ListQueryResult<CreditRequestViewModel> GetCommiteeRequests(CommiteeRequestsQuery query)
        {
            return RunListQuery<CommiteeRequestsQuery, CreditRequestDto>(_queryRepository, query)
                .MapTo<CreditRequestViewModel>();
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetCommiteeRequestsAsync(CommiteeRequestsQuery query)
        {
            return (await RunListQueryAsync<CommiteeRequestsQuery, CreditRequestDto>(_queryRepository, query))
                .MapTo<CreditRequestViewModel>();
        }

        public ListQueryResult<CreditRequestDto> GetDepartmentRequestsDtos(DepartmentRequestsQuery query)
        {
            return RunListQuery<DepartmentRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetDepartmentRequestsDtosAsync(DepartmentRequestsQuery query)
        {
            return await RunListQueryAsync<DepartmentRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public ListQueryResult<CreditRequestViewModel> GetDepartmentRequests(DepartmentRequestsQuery query)
        {
            return RunListQuery<DepartmentRequestsQuery, CreditRequestDto>(_queryRepository, query)
                .MapTo<CreditRequestViewModel>();
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetDepartmentRequestsAsync(DepartmentRequestsQuery query)
        {
            return (await RunListQueryAsync<DepartmentRequestsQuery, CreditRequestDto>(_queryRepository, query))
                .MapTo<CreditRequestViewModel>();
        }

        public ListQueryResult<CreditRequestDto> GetApprovedRequestsDtos(ApprovedRequestsQuery query)
        {
            return RunListQuery<ApprovedRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetApprovedRequestsDtosAsync(ApprovedRequestsQuery query)
        {
            return await RunListQueryAsync<ApprovedRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public ListQueryResult<CreditRequestViewModel> GetApprovedRequests(ApprovedRequestsQuery query)
        {
            return RunListQuery<ApprovedRequestsQuery, CreditRequestDto>(_queryRepository, query)
                .MapTo<CreditRequestViewModel>();
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetApprovedRequestsAsync(ApprovedRequestsQuery query)
        {
            return (await RunListQueryAsync<ApprovedRequestsQuery, CreditRequestDto>(_queryRepository, query))
                .MapTo<CreditRequestViewModel>();
        }

        public ListQueryResult<CreditRequestDto> GetApprovedClientRequestsDtos(ApprovedClientRequestsQuery query)
        {
            return RunListQuery<ApprovedClientRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetApprovedClientRequestsDtosAsync(ApprovedClientRequestsQuery query)
        {
            return await RunListQueryAsync<ApprovedClientRequestsQuery, CreditRequestDto>(_queryRepository, query);
        }

        public ListQueryResult<CreditRequestViewModel> GetApprovedClientRequests(ApprovedClientRequestsQuery query)
        {
            return RunListQuery<ApprovedClientRequestsQuery, CreditRequestDto>(_queryRepository, query)
                .MapTo<CreditRequestViewModel>();
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetApprovedClientRequestsAsync(ApprovedClientRequestsQuery query)
        {
            return (await RunListQueryAsync<ApprovedClientRequestsQuery, CreditRequestDto>(_queryRepository, query))
                .MapTo<CreditRequestViewModel>();
        }


        public ValueResult<bool> ValidateCreditRequest(CreditRequestViewModel request)
        {
            if (request?.CreditType?.Id == null)
            {
                return new ValueResult<bool>(false, false).Error("Credit Type not found");
            }
            var creditTypeRes = _creditTypeQueryRepository.GetModel(new ModelQuery {Id = request.CreditType.Id});
            if (creditTypeRes.IsFailed)
            {
                return new ValueResult<bool>(false, false).From(creditTypeRes);
            }
            foreach (var condition in creditTypeRes.Value.CreditConditions)
            {
                if (condition.MonthDurationFrom > request.MonthDuration ||
                    request.MonthDuration > condition.MonthDurationTo)
                    continue;
                if (condition.MinCreditSum.Currency.Id != request.CreditSum.Currency.Id)
                    continue;
                if (condition.MinCreditSum.Value > request.CreditSum.Value ||
                    request.CreditSum.Value > condition.MaxCreditSum.Value)
                    continue;
                return new ValueResult<bool>(true, true);
            }
            return new ValueResult<bool>(false, true).Error("None of the Credit Conditions are satisfied");
        }
    }
}