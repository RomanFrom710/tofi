using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;
using TOFI.TransferObjects.Credits.CreditRequest.Queries;

namespace BLL.Services.Credits.CreditRequest
{
    public interface ICreditRequestService : IModelService<CreditRequestDto, CreditRequestViewModel>
    {
        ListQueryResult<CreditRequestDto> GetClientRequestsDtos(ClientRequestsQuery query);

        Task<ListQueryResult<CreditRequestDto>> GetClientRequestsDtosAsync(ClientRequestsQuery query);

        ListQueryResult<CreditRequestViewModel> GetClientRequests(ClientRequestsQuery query);

        Task<ListQueryResult<CreditRequestViewModel>> GetClientRequestsAsync(ClientRequestsQuery query);
    }
}