using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Credits.CreditRequest;
using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.Employee.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Employee;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;
using TOFI.TransferObjects.Credits.CreditRequest.Queries;
using TOFI.TransferObjects.Employee.Commands;
using TOFI.TransferObjects.Employee.DataObjects;
using TOFI.TransferObjects.Employee.Queries;
using TOFI.TransferObjects.Model.Queries;

namespace BLL.Services.Employee
{
    public class EmployeeService : ModelService<EmployeeDto, EmployeeViewModel>, IEmployeeService
    {
        private readonly IEmployeeQueryRepository _queryRepository;
        private readonly IEmployeeCommandRepository _commandRepository;
        private readonly ICreditRequestService _creditRequestService;


        public EmployeeService(IEmployeeQueryRepository queryRepository, IEmployeeCommandRepository commandRepository,
            ICreditRequestService creditRequestService) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _creditRequestService = creditRequestService;
        }


        public ListQueryResult<CreditRequestDto> GetOperatorCreditRequestDtos(OperatorCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.Operator);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetOperatorRequestsDtos(new OperatorRequestsQuery());
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetOperatorCreditRequestDtosAsync(OperatorCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.Operator);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetOperatorRequestsDtos(new OperatorRequestsQuery());
        }

        public ListQueryResult<CreditRequestViewModel> GetOperatorCreditRequests(OperatorCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.Operator);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetOperatorRequests(new OperatorRequestsQuery());
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetOperatorCreditRequestsAsync(OperatorCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.Operator);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetOperatorRequests(new OperatorRequestsQuery());
        }

        public ListQueryResult<CreditRequestDto> GetSecurityCreditRequestDtos(SecurityCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.SecurityOfficer);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetSecurityRequestsDtos(new SecurityRequestsQuery());
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetSecurityCreditRequestDtosAsync(SecurityCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.SecurityOfficer);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetSecurityRequestsDtos(new SecurityRequestsQuery());
        }

        public ListQueryResult<CreditRequestViewModel> GetSecurityCreditRequests(SecurityCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.SecurityOfficer);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetSecurityRequests(new SecurityRequestsQuery());
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetSecurityCreditRequestsAsync(SecurityCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.SecurityOfficer);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetSecurityRequests(new SecurityRequestsQuery());
        }

        public ListQueryResult<CreditRequestDto> GetCommiteeCreditRequestDtos(CommiteeCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.CreditCommitteeMember);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetCommiteeRequestsDtos(new CommiteeRequestsQuery());
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetCommiteeCreditRequestDtosAsync(CommiteeCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.CreditCommitteeMember);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetCommiteeRequestsDtos(new CommiteeRequestsQuery());
        }

        public ListQueryResult<CreditRequestViewModel> GetCommiteeCreditRequests(CommiteeCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.CreditCommitteeMember);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetCommiteeRequests(new CommiteeRequestsQuery());
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetCommiteeCreditRequestsAsync(CommiteeCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.CreditCommitteeMember);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetCommiteeRequests(new CommiteeRequestsQuery());
        }

        public ListQueryResult<CreditRequestDto> GetDepartmentCreditRequestDtos(DepartmentCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.CreditDepartmentChief);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetDepartmentRequestsDtos(new DepartmentRequestsQuery());
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetDepartmentCreditRequestDtosAsync(DepartmentCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.CreditDepartmentChief);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetDepartmentRequestsDtos(new DepartmentRequestsQuery());
        }

        public ListQueryResult<CreditRequestViewModel> GetDepartmentCreditRequests(DepartmentCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.CreditDepartmentChief);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetDepartmentRequests(new DepartmentRequestsQuery());
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetDepartmentCreditRequestsAsync(DepartmentCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.CreditDepartmentChief);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return _creditRequestService.GetDepartmentRequests(new DepartmentRequestsQuery());
        }


        public CommandResult OperatorApproveCommand(OperatorApproveCommand command)
        {
            var rightsRes = CheckEmployeeRights(command.EmployeeId, EmployeeRights.Operator);
            var employeeRes = GetEmployee(command.EmployeeId);
            var requestRes = GetCreditRequest(command.CreditRequestId);
            var res = CheckQueries(rightsRes, employeeRes, requestRes);
            if (res.IsFailed)
            {
                return new CommandResult(command, false).From(res);
            }
            var request = requestRes.Value;
            request.IsOperatorApproved = command.Approved;
            request.OperatorComments = command.Comments;
            request.OperatorApproved = employeeRes.Value;
            return UpdateCreditRequest(command, request);
        }

        public async Task<CommandResult> OperatorApproveCommandAsync(OperatorApproveCommand command)
        {
            var rightsRes = await CheckEmployeeRightsAsync(command.EmployeeId, EmployeeRights.Operator);
            var employeeRes = await GetEmployeeAsync(command.EmployeeId);
            var requestRes = await GetCreditRequestAsync(command.CreditRequestId);
            var res = CheckQueries(rightsRes, employeeRes, requestRes);
            if (res.IsFailed)
            {
                return new CommandResult(command, false).From(res);
            }
            var request = requestRes.Value;
            request.IsOperatorApproved = command.Approved;
            request.OperatorComments = command.Comments;
            request.OperatorApproved = employeeRes.Value;
            return await UpdateCreditRequestAsync(command, request);
        }

        public CommandResult SecurityApproveCommand(SecurityApproveCommand command)
        {
            var rightsRes = CheckEmployeeRights(command.EmployeeId, EmployeeRights.SecurityOfficer);
            var employeeRes = GetEmployee(command.EmployeeId);
            var requestRes = GetCreditRequest(command.CreditRequestId);
            var res = CheckQueries(rightsRes, employeeRes, requestRes);
            if (res.IsFailed)
            {
                return new CommandResult(command, false).From(res);
            }
            var request = requestRes.Value;
            request.IsSecurityApproved = command.Approved;
            request.SecurityComments = command.Comments;
            request.SecurityApproved = employeeRes.Value;
            return UpdateCreditRequest(command, request);
        }

        public async Task<CommandResult> SecurityApproveCommandAsync(SecurityApproveCommand command)
        {
            var rightsRes = await CheckEmployeeRightsAsync(command.EmployeeId, EmployeeRights.SecurityOfficer);
            var employeeRes = await GetEmployeeAsync(command.EmployeeId);
            var requestRes = await GetCreditRequestAsync(command.CreditRequestId);
            var res = CheckQueries(rightsRes, employeeRes, requestRes);
            if (res.IsFailed)
            {
                return new CommandResult(command, false).From(res);
            }
            var request = requestRes.Value;
            request.IsSecurityApproved = command.Approved;
            request.SecurityComments = command.Comments;
            request.SecurityApproved = employeeRes.Value;
            return await UpdateCreditRequestAsync(command, request);
        }

        public CommandResult CommiteeApproveCommand(CommiteeApproveCommand command)
        {
            var rightsRes = CheckEmployeeRights(command.EmployeeId, EmployeeRights.CreditCommitteeMember);
            var employeeRes = GetEmployee(command.EmployeeId);
            var requestRes = GetCreditRequest(command.CreditRequestId);
            var res = CheckQueries(rightsRes, employeeRes, requestRes);
            if (res.IsFailed)
            {
                return new CommandResult(command, false).From(res);
            }
            var request = requestRes.Value;
            request.IsCreditCommitteeApproved = command.Approved;
            request.CreditCommitteeComments = command.Comments;
            request.CreditCommitteeApproved = employeeRes.Value;
            return UpdateCreditRequest(command, request);
        }

        public async Task<CommandResult> CommiteeApproveCommandAsync(CommiteeApproveCommand command)
        {
            var rightsRes = await CheckEmployeeRightsAsync(command.EmployeeId, EmployeeRights.CreditCommitteeMember);
            var employeeRes = await GetEmployeeAsync(command.EmployeeId);
            var requestRes = await GetCreditRequestAsync(command.CreditRequestId);
            var res = CheckQueries(rightsRes, employeeRes, requestRes);
            if (res.IsFailed)
            {
                return new CommandResult(command, false).From(res);
            }
            var request = requestRes.Value;
            request.IsCreditCommitteeApproved = command.Approved;
            request.CreditCommitteeComments = command.Comments;
            request.CreditCommitteeApproved = employeeRes.Value;
            return await UpdateCreditRequestAsync(command, request);
        }

        public CommandResult DepartmentApproveCommand(DepartmentApproveCommand command)
        {
            var rightsRes = CheckEmployeeRights(command.EmployeeId, EmployeeRights.CreditDepartmentChief);
            var employeeRes = GetEmployee(command.EmployeeId);
            var requestRes = GetCreditRequest(command.CreditRequestId);
            var res = CheckQueries(rightsRes, employeeRes, requestRes);
            if (res.IsFailed)
            {
                return new CommandResult(command, false).From(res);
            }
            var request = requestRes.Value;
            request.IsCreditDepartmentApproved = command.Approved;
            request.CreditDepartmentComments = command.Comments;
            request.CreditDepartmentApproved = employeeRes.Value;
            return UpdateCreditRequest(command, request);
        }

        public async Task<CommandResult> DepartmentApproveCommandAsync(DepartmentApproveCommand command)
        {
            var rightsRes = await CheckEmployeeRightsAsync(command.EmployeeId, EmployeeRights.CreditDepartmentChief);
            var employeeRes = await GetEmployeeAsync(command.EmployeeId);
            var requestRes = await GetCreditRequestAsync(command.CreditRequestId);
            var res = CheckQueries(rightsRes, employeeRes, requestRes);
            if (res.IsFailed)
            {
                return new CommandResult(command, false).From(res);
            }
            var request = requestRes.Value;
            request.IsCreditDepartmentApproved = command.Approved;
            request.CreditDepartmentComments = command.Comments;
            request.CreditDepartmentApproved = employeeRes.Value;
            return await UpdateCreditRequestAsync(command, request);
        }


        private ValueResult<bool> CheckEmployeeRights(int employeeId, EmployeeRights rights)
        {
            var employeeRes = GetModelDto(new ModelQuery { Id = employeeId });
            if (employeeRes.IsFailed)
            {
                return new ValueResult<bool>(false, false).From(employeeRes);
            }
            if (employeeRes.Value != null && employeeRes.Value.Rights.HasFlag(rights))
            {
                return new ValueResult<bool>(true, true);
            }
            return new ValueResult<bool>(false, true).Error("Not enough rights");
        }

        private async Task<ValueResult<bool>> CheckEmployeeRightsAsync(int employeeId, EmployeeRights rights)
        {
            var employeeRes = await GetModelDtoAsync(new ModelQuery { Id = employeeId });
            if (employeeRes.IsFailed)
            {
                return new ValueResult<bool>(false, false).From(employeeRes);
            }
            if (employeeRes.Value != null && employeeRes.Value.Rights.HasFlag(rights))
            {
                return new ValueResult<bool>(true, true);
            }
            return new ValueResult<bool>(false, true).Error("Not enough rights");
        }

        private ValueResult<EmployeeDto> GetEmployee(int employeeId)
        {
            var res = GetModelDto(new ModelQuery { Id = employeeId });
            if (res.IsFailed)
            {
                return new ValueResult<EmployeeDto>(null, false).From(res);
            }
            if (res.Value == null)
            {
                return new ValueResult<EmployeeDto>(null, false).Error("Employee not found");
            }
            return new ValueResult<EmployeeDto>(res.Value, true);
        }

        private async Task<ValueResult<EmployeeDto>> GetEmployeeAsync(int employeeId)
        {
            var res = await GetModelDtoAsync(new ModelQuery { Id = employeeId });
            if (res.IsFailed)
            {
                return new ValueResult<EmployeeDto>(null, false).From(res);
            }
            if (res.Value == null)
            {
                return new ValueResult<EmployeeDto>(null, false).Error("Employee not found");
            }
            return new ValueResult<EmployeeDto>(res.Value, true);
        }

        private ValueResult<CreditRequestDto> GetCreditRequest(int creditRequestId)
        {
            var res = _creditRequestService.GetModelDto(new ModelQuery { Id = creditRequestId });
            if (res.IsFailed)
            {
                return new ValueResult<CreditRequestDto>(null, false).From(res);
            }
            if (res.Value == null)
            {
                return new ValueResult<CreditRequestDto>(null, false).Error("Credit Request not found");
            }
            return new ValueResult<CreditRequestDto>(res.Value, true);
        }

        private async Task<ValueResult<CreditRequestDto>> GetCreditRequestAsync(int creditRequestId)
        {
            var res = await _creditRequestService.GetModelDtoAsync(new ModelQuery { Id = creditRequestId });
            if (res.IsFailed)
            {
                return new ValueResult<CreditRequestDto>(null, false).From(res);
            }
            if (res.Value == null)
            {
                return new ValueResult<CreditRequestDto>(null, false).Error("Credit Request not found");
            }
            return new ValueResult<CreditRequestDto>(res.Value, true);
        }

        private ServiceResult CheckQueries(ValueResult<bool> rightsRes, ValueResult<EmployeeDto> employeeRes,
            ValueResult<CreditRequestDto> requestRes)
        {
            if (rightsRes.IsFailed)
            {
                return new ServiceResult(false).From(rightsRes);
            }
            if (employeeRes.IsFailed)
            {
                return new ServiceResult(false).From(employeeRes);
            }
            if (requestRes.IsFailed)
            {
                return new ServiceResult(false).From(requestRes);
            }
            return new ServiceResult(true);
        }

        private CommandResult UpdateCreditRequest(ApproveCommand command, CreditRequestDto request)
        {
            var updateRes = _creditRequestService.UpdateModel(request);
            if (updateRes.IsFailed)
            {
                return new CommandResult(command, false).From(updateRes);
            }
            return new CommandResult(command, true);
        }

        private async Task<CommandResult> UpdateCreditRequestAsync(ApproveCommand command, CreditRequestDto request)
        {
            var updateRes = await _creditRequestService.UpdateModelAsync(request);
            if (updateRes.IsFailed)
            {
                return new CommandResult(command, false).From(updateRes);
            }
            return new CommandResult(command, true);
        }
    }
}