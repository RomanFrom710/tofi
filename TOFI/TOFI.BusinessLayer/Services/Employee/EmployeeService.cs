using System;
using System.Linq;
using System.Threading.Tasks;
using BLL.Result;
using BLL.Services.Actions.PaymentAction;
using BLL.Services.Actions.RequestAction;
using BLL.Services.Client;
using BLL.Services.Credits.CreditAccount;
using BLL.Services.Credits.CreditPayment;
using BLL.Services.Credits.CreditRequest;
using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.Email;
using BLL.Services.Employee.ViewModels;
using BLL.Services.Model;
using BLL.Services.Signature;
using DAL.Repositories.Employee;
using Newtonsoft.Json;
using TOFI.TransferObjects.Actions.PaymentAction.DataObjects;
using TOFI.TransferObjects.Actions.RequestAction.DataObjects;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Client.Queries;
using TOFI.TransferObjects.Common.Price.DataObjects;
using TOFI.TransferObjects.Credits.CreditAccount.Commands;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using TOFI.TransferObjects.Credits.CreditPayment.DataObjects;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;
using TOFI.TransferObjects.Credits.CreditRequest.Queries;
using TOFI.TransferObjects.Employee.Commands;
using TOFI.TransferObjects.Employee.DataObjects;
using TOFI.TransferObjects.Employee.Queries;
using TOFI.TransferObjects.Model.Queries;
using ApprovedClientRequestsQuery = TOFI.TransferObjects.Employee.Queries.ApprovedClientRequestsQuery;

namespace BLL.Services.Employee
{
    public class EmployeeService : ModelService<EmployeeDto, EmployeeViewModel>, IEmployeeService
    {
        private readonly IEmployeeQueryRepository _queryRepository;
        private readonly IEmployeeCommandRepository _commandRepository;
        private readonly ICreditRequestService _creditRequestService;
        private readonly IClientService _clientService;
        private readonly ICreditAccountService _creditAccountService;
        private readonly IEmailService _emailService;
        private readonly ICreditPaymentService _creditPaymentService;
        private readonly IRequestActionService _requestActionService;
        private readonly IPaymentActionService _paymentActionService;
        private readonly ISignatureService _signatureService;


        public EmployeeService(IEmployeeQueryRepository queryRepository, IEmployeeCommandRepository commandRepository,
            ICreditRequestService creditRequestService, IClientService clientService,
            ICreditAccountService creditAccountService, IEmailService emailService,
            ICreditPaymentService creditPaymentService, IRequestActionService requestActionService,
            IPaymentActionService paymentActionService, ISignatureService signatureService)
            : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _creditRequestService = creditRequestService;
            _clientService = clientService;
            _creditAccountService = creditAccountService;
            _emailService = emailService;
            _creditPaymentService = creditPaymentService;
            _requestActionService = requestActionService;
            _paymentActionService = paymentActionService;
            _signatureService = signatureService;
        }


        public QueryResult<EmployeeDto> GetEmployeeDto(EmployeeQuery query)
        {
            return RunQuery<EmployeeQuery, EmployeeDto>(_queryRepository, query);
        }

        public async Task<QueryResult<EmployeeDto>> GetEmployeeDtoAsync(EmployeeQuery query)
        {
            return await RunQueryAsync<EmployeeQuery, EmployeeDto>(_queryRepository, query);
        }

        public QueryResult<EmployeeViewModel> GetEmployee(EmployeeQuery query)
        {
            return RunQuery<EmployeeQuery, EmployeeDto>(_queryRepository, query).MapTo<EmployeeViewModel>();
        }

        public async Task<QueryResult<EmployeeViewModel>> GetEmployeeAsync(EmployeeQuery query)
        {
            return (await RunQueryAsync<EmployeeQuery, EmployeeDto>(_queryRepository, query)).MapTo<EmployeeViewModel>();
        }

        public ListQueryResult<CreditRequestDto> GetOperatorCreditRequestDtos(OperatorCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.Operator);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return Filter(_creditRequestService.GetOperatorRequestsDtos(new OperatorRequestsQuery()), query);
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetOperatorCreditRequestDtosAsync(OperatorCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.Operator);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return Filter(await _creditRequestService.GetOperatorRequestsDtosAsync(new OperatorRequestsQuery()), query);
        }

        public ListQueryResult<CreditRequestViewModel> GetOperatorCreditRequests(OperatorCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.Operator);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return Filter(_creditRequestService.GetOperatorRequests(new OperatorRequestsQuery()), query);
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetOperatorCreditRequestsAsync(OperatorCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.Operator);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return Filter(await _creditRequestService.GetOperatorRequestsAsync(new OperatorRequestsQuery()), query);
        }

        public ListQueryResult<CreditRequestDto> GetSecurityCreditRequestDtos(SecurityCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.SecurityOfficer);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return Filter(_creditRequestService.GetSecurityRequestsDtos(new SecurityRequestsQuery()), query);
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetSecurityCreditRequestDtosAsync(SecurityCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.SecurityOfficer);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return Filter(await _creditRequestService.GetSecurityRequestsDtosAsync(new SecurityRequestsQuery()), query);
        }

        public ListQueryResult<CreditRequestViewModel> GetSecurityCreditRequests(SecurityCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.SecurityOfficer);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return Filter(_creditRequestService.GetSecurityRequests(new SecurityRequestsQuery()), query);
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetSecurityCreditRequestsAsync(SecurityCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.SecurityOfficer);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return Filter(await _creditRequestService.GetSecurityRequestsAsync(new SecurityRequestsQuery()), query);
        }

        public ListQueryResult<CreditRequestDto> GetCommiteeCreditRequestDtos(CommiteeCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.CreditCommitteeMember);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return Filter(_creditRequestService.GetCommiteeRequestsDtos(new CommiteeRequestsQuery()), query);
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetCommiteeCreditRequestDtosAsync(CommiteeCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.CreditCommitteeMember);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return Filter(await _creditRequestService.GetCommiteeRequestsDtosAsync(new CommiteeRequestsQuery()), query);
        }

        public ListQueryResult<CreditRequestViewModel> GetCommiteeCreditRequests(CommiteeCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.CreditCommitteeMember);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return Filter(_creditRequestService.GetCommiteeRequests(new CommiteeRequestsQuery()), query);
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetCommiteeCreditRequestsAsync(CommiteeCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.CreditCommitteeMember);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return Filter(await _creditRequestService.GetCommiteeRequestsAsync(new CommiteeRequestsQuery()), query);
        }

        public ListQueryResult<CreditRequestDto> GetDepartmentCreditRequestDtos(DepartmentCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.CreditDepartmentChief);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return Filter(_creditRequestService.GetDepartmentRequestsDtos(new DepartmentRequestsQuery()), query);
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetDepartmentCreditRequestDtosAsync(DepartmentCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.CreditDepartmentChief);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            return Filter(await _creditRequestService.GetDepartmentRequestsDtosAsync(new DepartmentRequestsQuery()), query);
        }

        public ListQueryResult<CreditRequestViewModel> GetDepartmentCreditRequests(DepartmentCreditRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.CreditDepartmentChief);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return Filter(_creditRequestService.GetDepartmentRequests(new DepartmentRequestsQuery()), query);
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetDepartmentCreditRequestsAsync(DepartmentCreditRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.CreditDepartmentChief);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            return Filter(await _creditRequestService.GetDepartmentRequestsAsync(new DepartmentRequestsQuery()), query);
        }

        public ListQueryResult<CreditRequestDto> GetApprovedClientRequestDtos(ApprovedClientRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.Operator);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            var clientRes = GetClient(query.ClientId, query.PassportNumber);
            if (clientRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(clientRes);
            }
            return _creditRequestService.GetApprovedClientRequestsDtos(
                new TOFI.TransferObjects.Credits.CreditRequest.Queries.ApprovedClientRequestsQuery
                {
                    ClientId = clientRes.Value.Id
                });
        }

        public async Task<ListQueryResult<CreditRequestDto>> GetApprovedClientRequestDtosAsync(ApprovedClientRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.Operator);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(rightsRes);
            }
            var clientRes = await GetClientAsync(query.ClientId, query.PassportNumber);
            if (clientRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestDto>(query, null, false).From(clientRes);
            }
            return await _creditRequestService.GetApprovedClientRequestsDtosAsync(
                new TOFI.TransferObjects.Credits.CreditRequest.Queries.ApprovedClientRequestsQuery
                {
                    ClientId = clientRes.Value.Id
                });
        }

        public ListQueryResult<CreditRequestViewModel> GetApprovedClientRequests(ApprovedClientRequestsQuery query)
        {
            var rightsRes = CheckEmployeeRights(query.EmployeeId, EmployeeRights.Operator);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            var clientRes = GetClient(query.ClientId, query.PassportNumber);
            if (clientRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(clientRes);
            }
            return _creditRequestService.GetApprovedClientRequests(
                new TOFI.TransferObjects.Credits.CreditRequest.Queries.ApprovedClientRequestsQuery
                {
                    ClientId = clientRes.Value.Id
                });
        }

        public async Task<ListQueryResult<CreditRequestViewModel>> GetApprovedClientRequestsAsync(ApprovedClientRequestsQuery query)
        {
            var rightsRes = await CheckEmployeeRightsAsync(query.EmployeeId, EmployeeRights.Operator);
            if (rightsRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(rightsRes);
            }
            var clientRes = GetClient(query.ClientId, query.PassportNumber);
            if (clientRes.IsFailed)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, null, false).From(clientRes);
            }
            return _creditRequestService.GetApprovedClientRequests(
                new TOFI.TransferObjects.Credits.CreditRequest.Queries.ApprovedClientRequestsQuery
                {
                    ClientId = clientRes.Value.Id
                });
        }


        public CommandResult AddOrUpdateEmployee(EmployeeViewModel employee)
        {
            var employeeRes = GetEmployeeDto(EmployeeQuery.WithUserId(employee.User.Id));
            if (employeeRes.IsFailed)
            {
                return new CommandResult(null, false).From(employeeRes);
            }
            return employeeRes.Value == null ? CreateModel(employee) : UpdateModel(employee);
        }

        public async Task<CommandResult> AddOrUpdateEmployeeAsync(EmployeeViewModel employee)
        {
            var employeeRes = await GetEmployeeDtoAsync(EmployeeQuery.WithUserId(employee.User.Id));
            if (employeeRes.IsFailed)
            {
                return new CommandResult(null, false).From(employeeRes);
            }
            return await (employeeRes.Value == null ? CreateModelAsync(employee) : UpdateModelAsync(employee));
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
            var updateRes = UpdateCreditRequest(command, request);
            if (request.Client.User.EmailConfirmed && !updateRes.IsFailed)
                Task.Run(async () => await _emailService.SendRequestApprovedNotification(request.Client.User.Email));
            return updateRes;
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
            var updateRes = await UpdateCreditRequestAsync(command, request);
            if (request.Client.User.EmailConfirmed && !updateRes.IsFailed)
                await _emailService.SendRequestApprovedNotification(request.Client.User.Email);
            return updateRes;
        }

        public CommandResult OpenCreditAccount(OpenCreditAccountCommand command)
        {
            var rightsRes = CheckEmployeeRights(command.EmployeeId, EmployeeRights.Operator);
            var employeeRes = GetEmployee(command.EmployeeId);
            var requestRes = GetCreditRequest(command.CreditRequestId);
            var res = CheckQueries(rightsRes, employeeRes, requestRes);
            if (res.IsFailed)
            {
                return new CommandResult(command, false).From(res);
            }
            var accountRes = _creditAccountService.OpenCreditAccount(new OpenAccountCommand {Request = requestRes.Value});
            if (accountRes.IsFailed)
            {
                return new CommandResult(command, false).From(accountRes);
            }
            var request = requestRes.Value;
            request.IsOpen = true;
            request.RequestOpener = employeeRes.Value;
            var updateRes = _creditRequestService.UpdateModel(request);
            if (updateRes.IsFailed)
            {
                return new CommandResult(command, false).From(updateRes);
            }
            var action = new RequestActionDto
            {
                Timestamp = DateTime.Now,
                Employee = employeeRes.Value,
                CreditRequest = request,
                ActionType = GetActionType(command.GetType().Name)
            };
            action.Signature = GetOpenAccountSignature(action);
            _requestActionService.CreateModel(action);
            return new CommandResult(command, true);
        }

        public async Task<CommandResult> OpenCreditAccountAsync(OpenCreditAccountCommand command)
        {
            var rightsRes = await CheckEmployeeRightsAsync(command.EmployeeId, EmployeeRights.Operator);
            var employeeRes = await GetEmployeeAsync(command.EmployeeId);
            var requestRes = await GetCreditRequestAsync(command.CreditRequestId);
            var res = CheckQueries(rightsRes, employeeRes, requestRes);
            if (res.IsFailed)
            {
                return new CommandResult(command, false).From(res);
            }
            var accountRes = await _creditAccountService.OpenCreditAccountAsync(new OpenAccountCommand {Request = requestRes.Value});
            if (accountRes.IsFailed)
            {
                return new CommandResult(command, false).From(accountRes);
            }
            var request = requestRes.Value;
            request.IsOpen = true;
            request.RequestOpener = employeeRes.Value;
            var updateRes = await _creditRequestService.UpdateModelAsync(request);
            if (updateRes.IsFailed)
            {
                return new CommandResult(command, false).From(updateRes);
            }
            var action = new RequestActionDto
            {
                Timestamp = DateTime.Now,
                Employee = employeeRes.Value,
                CreditRequest = request,
                ActionType = GetActionType(command.GetType().Name)
            };
            action.Signature = GetOpenAccountSignature(action);
            await _requestActionService.CreateModelAsync(action);
            return new CommandResult(command, true);
        }

        public CommandResult AddPayment(AddPaymentCommand command)
        {
            var rightsRes = CheckEmployeeRights(command.EmployeeId, EmployeeRights.Cashier);
            var employeeRes = GetEmployee(command.EmployeeId);
            var accountRes = GetCreditAccount(command.CreditAccountId);
            var res = CheckPayment(rightsRes, employeeRes, accountRes, command.PaymentSum);
            if (res.IsFailed)
            {
                return new CommandResult(command, false).From(res);
            }
            var payment = new CreditPaymentDto
            {
                Timestamp = DateTime.Now,
                PaymentSum = command.PaymentSum,
                CreditAccount = accountRes.Value,
                Employee = employeeRes.Value
            };
            var paymentRes = _creditPaymentService.CreateModel(payment);
            if (paymentRes.IsFailed)
            {
                return new CommandResult(command, false).From(paymentRes);
            }
            var action = new PaymentActionDto
            {
                Timestamp = DateTime.Now,
                Employee = employeeRes.Value,
                CreditPayment = payment,
                ActionType = GetActionType(command.GetType().Name)
            };
            action.Signature = GetPaymentSignature(action);
            _paymentActionService.CreateModel(action);
            return new CommandResult(command, true);
        }

        public async Task<CommandResult> AddPaymentAsync(AddPaymentCommand command)
        {
            var rightsRes = await CheckEmployeeRightsAsync(command.EmployeeId, EmployeeRights.Cashier);
            var employeeRes = await GetEmployeeAsync(command.EmployeeId);
            var accountRes = await GetCreditAccountAsync(command.CreditAccountId);
            var res = CheckPayment(rightsRes, employeeRes, accountRes, command.PaymentSum);
            if (res.IsFailed)
            {
                return new CommandResult(command, false).From(res);
            }
            var payment = new CreditPaymentDto
            {
                Timestamp = DateTime.Now,
                PaymentSum = command.PaymentSum,
                CreditAccount = accountRes.Value,
                Employee = employeeRes.Value
            };
            var paymentRes = await _creditPaymentService.CreateModelAsync(payment);
            if (paymentRes.IsFailed)
            {
                return new CommandResult(command, false).From(paymentRes);
            }
            var action = new PaymentActionDto
            {
                Timestamp = DateTime.Now,
                Employee = employeeRes.Value,
                CreditPayment = payment,
                ActionType = GetActionType(command.GetType().Name)
            };
            action.Signature = GetPaymentSignature(action);
            await _paymentActionService.CreateModelAsync(action);
            return new CommandResult(command, true);
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

        private ValueResult<ClientDto> GetClient(int? clientId, string passportNumber)
        {
            var res = _clientService.GetClientDto(new ClientQuery {Id = clientId, PassportNumber = passportNumber});
            if (res.IsFailed)
            {
                return new ValueResult<ClientDto>(null, false).From(res);
            }
            if (res.Value == null)
            {
                return new ValueResult<ClientDto>(null, false).Error("Employee not found");
            }
            return new ValueResult<ClientDto>(res.Value, true);
        }

        private async Task<ValueResult<ClientDto>> GetClientAsync(int? clientId, string passportNumber)
        {
            var res = await _clientService.GetClientDtoAsync(new ClientQuery {Id = clientId, PassportNumber = passportNumber});
            if (res.IsFailed)
            {
                return new ValueResult<ClientDto>(null, false).From(res);
            }
            if (res.Value == null)
            {
                return new ValueResult<ClientDto>(null, false).Error("Client not found");
            }
            return new ValueResult<ClientDto>(res.Value, true);
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

        private ValueResult<CreditAccountDto> GetCreditAccount(int creditAccountId)
        {
            var res = _creditAccountService.GetModelDto(new ModelQuery { Id = creditAccountId });
            if (res.IsFailed)
            {
                return new ValueResult<CreditAccountDto>(null, false).From(res);
            }
            if (res.Value == null)
            {
                return new ValueResult<CreditAccountDto>(null, false).Error("Credit Account not found");
            }
            return new ValueResult<CreditAccountDto>(res.Value, true);
        }

        private async Task<ValueResult<CreditAccountDto>> GetCreditAccountAsync(int creditAccountId)
        {
            var res = await _creditAccountService.GetModelDtoAsync(new ModelQuery { Id = creditAccountId });
            if (res.IsFailed)
            {
                return new ValueResult<CreditAccountDto>(null, false).From(res);
            }
            if (res.Value == null)
            {
                return new ValueResult<CreditAccountDto>(null, false).Error("Credit Account not found");
            }
            return new ValueResult<CreditAccountDto>(res.Value, true);
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

        private ServiceResult CheckPayment(ValueResult<bool> rightsRes, ValueResult<EmployeeDto> employeeRes,
            ValueResult<CreditAccountDto> accountRes, PriceDto price)
        {
            if (rightsRes.IsFailed)
            {
                return new ServiceResult(false).From(rightsRes);
            }
            if (employeeRes.IsFailed)
            {
                return new ServiceResult(false).From(employeeRes);
            }
            if (accountRes.IsFailed)
            {
                return new ServiceResult(false).From(accountRes);
            }
            if (accountRes.Value.Currency.Id != price.Currency.Id)
            {
                return new ServiceResult(false).Error("Payment currency should equal account currency");
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
            var signRes = SignApprove(command, request);
            if (signRes.IsFailed)
            {
                //Well this is not good
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
            var signRes = await SignApproveAsync(command, request);
            if (signRes.IsFailed)
            {
                //Well this is not good
            }
            return new CommandResult(command, true);
        }

        private CommandResult SignApprove(ApproveCommand command, CreditRequestDto request)
        {
            var employeeRes = GetEmployee(command.EmployeeId);
            if (employeeRes.IsFailed)
            {
                return new CommandResult(command, false).From(employeeRes);
            }
            if (employeeRes.Value == null || request == null)
            {
                return new CommandResult(command, false).Error("Invalid command");
            }
            var action = new RequestActionDto
            {
                Timestamp = DateTime.Now,
                Employee = employeeRes.Value,
                CreditRequest = request,
                ActionType = GetActionType(command.GetType().Name)
            };
            action.Signature = GetApproveSignature(action, command);
            return _requestActionService.CreateModel(action);
        }

        private async Task<CommandResult> SignApproveAsync(ApproveCommand command, CreditRequestDto request)
        {
            var employeeRes = await GetEmployeeAsync(command.EmployeeId);
            if (employeeRes.IsFailed)
            {
                return new CommandResult(command, false).From(employeeRes);
            }
            if (employeeRes.Value == null || request == null)
            {
                return new CommandResult(command, false).Error("Invalid command");
            }
            var action = new RequestActionDto
            {
                Timestamp = DateTime.Now,
                Employee = employeeRes.Value,
                CreditRequest = request,
                ActionType = GetActionType(command.GetType().Name)
            };
            action.Signature = GetApproveSignature(action, command);
            return await _requestActionService.CreateModelAsync(action);
        }

        private string GetActionType(string commandName)
        {
            if (commandName == typeof(OperatorApproveCommand).Name)
                return "operator approve";
            if (commandName == typeof(SecurityApproveCommand).Name)
                return "security approve";
            if (commandName == typeof(CommiteeApproveCommand).Name)
                return "commitee approve";
            if (commandName == typeof(DepartmentApproveCommand).Name)
                return "department approve";
            if (commandName == typeof(OpenCreditAccountCommand).Name)
                return "open credit account";
            if (commandName == typeof(AddPaymentCommand).Name)
                return "add payment";
            return string.Empty;
        }

        private string GetApproveSignature(RequestActionDto action, ApproveCommand command)
        {
            var data = new
            {
                action.Timestamp,
                action.ActionType,
                command.Approved,
                command.Comments,
                EmployeeId = action.Employee.Id,
                CreditRequestId = action.CreditRequest.Id,
                Duration = action.CreditRequest.MonthDuration,
                Sum = action.CreditRequest.CreditSum.Value,
                SumCurrencyId = action.CreditRequest.CreditSum.Currency.Id,
                CreditTypeId = action.CreditRequest.CreditType.Id
            };
            var json = JsonConvert.SerializeObject(data);
            return _signatureService.Sign(json, action.Employee.User.Key).Value;
        }

        private string GetOpenAccountSignature(RequestActionDto action)
        {
            var data = new
            {
                action.Timestamp,
                action.ActionType,
                EmployeeId = action.Employee.Id,
                CreditRequestId = action.CreditRequest.Id,
                Duration = action.CreditRequest.MonthDuration,
                Sum = action.CreditRequest.CreditSum.Value,
                SumCurrencyId = action.CreditRequest.CreditSum.Currency.Id,
                CreditTypeId = action.CreditRequest.CreditType.Id
            };
            var json = JsonConvert.SerializeObject(data);
            return _signatureService.Sign(json, action.Employee.User.Key).Value;
        }

        private string GetPaymentSignature(PaymentActionDto action)
        {
            var data = new
            {
                action.Timestamp,
                action.ActionType,
                EmployeeId = action.Employee.Id,
                CreditPaymentId = action.CreditPayment.Id,
                CreditPaymentTimeStamp = action.CreditPayment.Timestamp,
                CreditAccountId = action.CreditPayment.CreditAccount.Id,
                PaymentSum = action.CreditPayment.PaymentSum.Value,
                PaymentCurrencyId = action.CreditPayment.PaymentSum.Currency.Id
            };
            var json = JsonConvert.SerializeObject(data);
            return _signatureService.Sign(json, action.Employee.User.Key).Value;
        }

        private ListQueryResult<CreditRequestDto> Filter(ListQueryResult<CreditRequestDto> res,
            CreditRequestsQuery query)
        {
            if (res.Value == null)
            {
                return new ListQueryResult<CreditRequestDto>(query, Enumerable.Empty<CreditRequestDto>());
            }
            var requests =
                res.Value.Where(r => (!query.CreditTypeId.HasValue || query.CreditTypeId == r.CreditType.Id) &&
                                     (!query.CreditSumCurrencyId.HasValue ||
                                      query.CreditSumCurrencyId == r.CreditSum.Currency.Id) &&
                                     (!query.MinCreditSumValue.HasValue || query.MinCreditSumValue <= r.CreditSum.Value));
            return new ListQueryResult<CreditRequestDto>(query, requests);
        }

        private ListQueryResult<CreditRequestViewModel> Filter(ListQueryResult<CreditRequestViewModel> res,
            CreditRequestsQuery query)
        {
            if (res.Value == null)
            {
                return new ListQueryResult<CreditRequestViewModel>(query, Enumerable.Empty<CreditRequestViewModel>());
            }
            var requests =
                res.Value.Where(r => (!query.CreditTypeId.HasValue || query.CreditTypeId == r.CreditType.Id) &&
                                     (!query.CreditSumCurrencyId.HasValue ||
                                      query.CreditSumCurrencyId == r.CreditSum.Currency.Id) &&
                                     (!query.MinCreditSumValue.HasValue || query.MinCreditSumValue <= r.CreditSum.Value));
            return new ListQueryResult<CreditRequestViewModel>(query, requests);
        }
    }
}