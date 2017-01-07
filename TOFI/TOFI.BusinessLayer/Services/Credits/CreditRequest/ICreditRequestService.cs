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

        ListQueryResult<CreditRequestDto> GetOperatorRequestsDtos(OperatorRequestsQuery query);

        Task<ListQueryResult<CreditRequestDto>> GetOperatorRequestsDtosAsync(OperatorRequestsQuery query);

        ListQueryResult<CreditRequestViewModel> GetOperatorRequests(OperatorRequestsQuery query);

        Task<ListQueryResult<CreditRequestViewModel>> GetOperatorRequestsAsync(OperatorRequestsQuery query);

        ListQueryResult<CreditRequestDto> GetSecurityRequestsDtos(SecurityRequestsQuery query);

        Task<ListQueryResult<CreditRequestDto>> GetSecurityRequestsDtosAsync(SecurityRequestsQuery query);

        ListQueryResult<CreditRequestViewModel> GetSecurityRequests(SecurityRequestsQuery query);

        Task<ListQueryResult<CreditRequestViewModel>> GetSecurityRequestsAsync(SecurityRequestsQuery query);

        ListQueryResult<CreditRequestDto> GetCommiteeRequestsDtos(CommiteeRequestsQuery query);

        Task<ListQueryResult<CreditRequestDto>> GetCommiteeRequestsDtosAsync(CommiteeRequestsQuery query);

        ListQueryResult<CreditRequestViewModel> GetCommiteeRequests(CommiteeRequestsQuery query);

        Task<ListQueryResult<CreditRequestViewModel>> GetCommiteeRequestsAsync(CommiteeRequestsQuery query);

        ListQueryResult<CreditRequestDto> GetDepartmentRequestsDtos(DepartmentRequestsQuery query);

        Task<ListQueryResult<CreditRequestDto>> GetDepartmentRequestsDtosAsync(DepartmentRequestsQuery query);

        ListQueryResult<CreditRequestViewModel> GetDepartmentRequests(DepartmentRequestsQuery query);

        Task<ListQueryResult<CreditRequestViewModel>> GetDepartmentRequestsAsync(DepartmentRequestsQuery query);

        ListQueryResult<CreditRequestDto> GetApprovedRequestsDtos(ApprovedRequestsQuery query);

        Task<ListQueryResult<CreditRequestDto>> GetApprovedRequestsDtosAsync(ApprovedRequestsQuery query);

        ListQueryResult<CreditRequestViewModel> GetApprovedRequests(ApprovedRequestsQuery query);

        Task<ListQueryResult<CreditRequestViewModel>> GetApprovedRequestsAsync(ApprovedRequestsQuery query);

        ListQueryResult<CreditRequestDto> GetApprovedClientRequestsDtos(ApprovedClientRequestsQuery query);

        Task<ListQueryResult<CreditRequestDto>> GetApprovedClientRequestsDtosAsync(ApprovedClientRequestsQuery query);

        ListQueryResult<CreditRequestViewModel> GetApprovedClientRequests(ApprovedClientRequestsQuery query);

        Task<ListQueryResult<CreditRequestViewModel>> GetApprovedClientRequestsAsync(ApprovedClientRequestsQuery query);

        ValueResult<bool> ValidateCreditRequest(CreditRequestViewModel request);
    }
}