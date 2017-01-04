using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.Employee.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;
using TOFI.TransferObjects.Employee.Commands;
using TOFI.TransferObjects.Employee.DataObjects;
using TOFI.TransferObjects.Employee.Queries;

namespace BLL.Services.Employee
{
    public interface IEmployeeService : IModelService<EmployeeDto, EmployeeViewModel>
    {
        ListQueryResult<CreditRequestDto> GetOperatorCreditRequestDtos(OperatorCreditRequestsQuery query);

        Task<ListQueryResult<CreditRequestDto>> GetOperatorCreditRequestDtosAsync(OperatorCreditRequestsQuery query);

        ListQueryResult<CreditRequestViewModel> GetOperatorCreditRequests(OperatorCreditRequestsQuery query);

        Task<ListQueryResult<CreditRequestViewModel>> GetOperatorCreditRequestsAsync(OperatorCreditRequestsQuery query);

        ListQueryResult<CreditRequestDto> GetSecurityCreditRequestDtos(SecurityCreditRequestsQuery query);

        Task<ListQueryResult<CreditRequestDto>> GetSecurityCreditRequestDtosAsync(SecurityCreditRequestsQuery query);

        ListQueryResult<CreditRequestViewModel> GetSecurityCreditRequests(SecurityCreditRequestsQuery query);

        Task<ListQueryResult<CreditRequestViewModel>> GetSecurityCreditRequestsAsync(SecurityCreditRequestsQuery query);

        ListQueryResult<CreditRequestDto> GetCommiteeCreditRequestDtos(CommiteeCreditRequestsQuery query);

        Task<ListQueryResult<CreditRequestDto>> GetCommiteeCreditRequestDtosAsync(CommiteeCreditRequestsQuery query);

        ListQueryResult<CreditRequestViewModel> GetCommiteeCreditRequests(CommiteeCreditRequestsQuery query);

        Task<ListQueryResult<CreditRequestViewModel>> GetCommiteeCreditRequestsAsync(CommiteeCreditRequestsQuery query);

        ListQueryResult<CreditRequestDto> GetDepartmentCreditRequestDtos(DepartmentCreditRequestsQuery query);

        Task<ListQueryResult<CreditRequestDto>> GetDepartmentCreditRequestDtosAsync(DepartmentCreditRequestsQuery query);

        ListQueryResult<CreditRequestViewModel> GetDepartmentCreditRequests(DepartmentCreditRequestsQuery query);

        Task<ListQueryResult<CreditRequestViewModel>> GetDepartmentCreditRequestsAsync(DepartmentCreditRequestsQuery query);


        CommandResult OperatorApproveCommand(OperatorApproveCommand command);

        Task<CommandResult> OperatorApproveCommandAsync(OperatorApproveCommand command);

        CommandResult SecurityApproveCommand(SecurityApproveCommand command);

        Task<CommandResult> SecurityApproveCommandAsync(SecurityApproveCommand command);

        CommandResult CommiteeApproveCommand(CommiteeApproveCommand command);

        Task<CommandResult> CommiteeApproveCommandAsync(CommiteeApproveCommand command);

        CommandResult DepartmentApproveCommand(DepartmentApproveCommand command);

        Task<CommandResult> DepartmentApproveCommandAsync(DepartmentApproveCommand command);
    }
}