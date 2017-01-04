using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.CreditRequest;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;
using TOFI.TransferObjects.Credits.CreditRequest.Queries;

namespace BLL.Services.Credits.CreditRequest
{
    public class CreditRequestService : ModelService<CreditRequestDto, CreditRequestViewModel>, ICreditRequestService
    {
        private readonly ICreditRequestQueryRepository _queryRepository;
        private readonly ICreditRequestCommandRepository _commandRepository;


        public CreditRequestService(ICreditRequestQueryRepository queryRepository,
            ICreditRequestCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
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
    }
}