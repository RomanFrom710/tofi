using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.Employee.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Employee;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;
using TOFI.TransferObjects.Employee.Commands;
using TOFI.TransferObjects.Employee.DataObjects;
using TOFI.TransferObjects.Employee.Queries;

namespace BLL.Services.Employee
{
    public class EmployeeService : ModelService<EmployeeDto, EmployeeViewModel>, IEmployeeService
    {
        private readonly IEmployeeQueryRepository _queryRepository;
        private readonly IEmployeeCommandRepository _commandRepository;


        public EmployeeService(IEmployeeQueryRepository queryRepository, IEmployeeCommandRepository commandRepository)
            : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }


        public ListQueryResult<CreditRequestDto> GetOperatorCreditRequestDtos(OperatorCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public Task<ListQueryResult<CreditRequestDto>> GetOperatorCreditRequestDtosAsync(OperatorCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public ListQueryResult<CreditRequestViewModel> GetOperatorCreditRequests(OperatorCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public Task<ListQueryResult<CreditRequestViewModel>> GetOperatorCreditRequestsAsync(OperatorCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public ListQueryResult<CreditRequestDto> GetSecurityCreditRequestDtos(SecurityCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public Task<ListQueryResult<CreditRequestDto>> GetSecurityCreditRequestDtosAsync(SecurityCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public ListQueryResult<CreditRequestViewModel> GetSecurityCreditRequests(SecurityCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public Task<ListQueryResult<CreditRequestViewModel>> GetSecurityCreditRequestsAsync(SecurityCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public ListQueryResult<CreditRequestDto> GetCommiteeCreditRequestDtos(CommiteeCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public Task<ListQueryResult<CreditRequestDto>> GetCommiteeCreditRequestDtosAsync(CommiteeCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public ListQueryResult<CreditRequestViewModel> GetCommiteeCreditRequests(CommiteeCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public Task<ListQueryResult<CreditRequestViewModel>> GetCommiteeCreditRequestsAsync(CommiteeCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public ListQueryResult<CreditRequestDto> GetDepartmentCreditRequestDtos(DepartmentCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public Task<ListQueryResult<CreditRequestDto>> GetDepartmentCreditRequestDtosAsync(DepartmentCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public ListQueryResult<CreditRequestViewModel> GetDepartmentCreditRequests(DepartmentCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }

        public Task<ListQueryResult<CreditRequestViewModel>> GetDepartmentCreditRequestsAsync(DepartmentCreditRequestsQuery query)
        {
            throw new System.NotImplementedException();
        }


        public CommandResult OperatorApproveCommand(OperatorApproveCommand command)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommandResult> OperatorApproveCommandAsync(OperatorApproveCommand command)
        {
            throw new System.NotImplementedException();
        }

        public CommandResult SecurityApproveCommand(SecurityApproveCommand command)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommandResult> SecurityApproveCommandAsync(SecurityApproveCommand command)
        {
            throw new System.NotImplementedException();
        }

        public CommandResult CommiteeApproveCommand(CommiteeApproveCommand command)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommandResult> CommiteeApproveCommandAsync(CommiteeApproveCommand command)
        {
            throw new System.NotImplementedException();
        }

        public CommandResult DepartmentApproveCommand(DepartmentApproveCommand command)
        {
            throw new System.NotImplementedException();
        }

        public Task<CommandResult> DepartmentApproveCommandAsync(DepartmentApproveCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}