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
    }
}