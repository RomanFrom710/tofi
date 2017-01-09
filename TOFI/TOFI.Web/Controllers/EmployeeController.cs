using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BLL.Services.Common.Currency;
using BLL.Services.Common.Currency.ViewModels;
using BLL.Services.Credits.BankCredits.CreditTypes;
using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Credits.CreditAccount;
using BLL.Services.Credits.CreditAccountState.ViewModels;
using BLL.Services.Credits.CreditRequest;
using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.Employee;
using BLL.Services.Employee.ViewModels;
using Microsoft.AspNet.Identity;
using TOFI.TransferObjects.Credits.CreditAccount.Queries;
using TOFI.TransferObjects.Employee.Commands;
using TOFI.TransferObjects.Employee.Queries;
using TOFI.TransferObjects.Model.Queries;
using TOFI.Web.Infrastructure;

namespace TOFI.Web.Controllers
{
    [EmployeePasswordChange]
    [Authorize(Roles = "employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICreditRequestService _creditRequestService;
        private readonly ICreditAccountService _creditAccountService;

        private readonly IEnumerable<CreditTypeViewModel> _creditTypes;
        private readonly IEnumerable<CurrencyViewModel> _currencies;

        public EmployeeController(IEmployeeService employeeService,
                                  ICurrencyService currencyService,
                                  ICreditTypeService creditTypeService,
                                  ICreditRequestService creditRequestService,
                                  ICreditAccountService creditAccountService)
        {
            _employeeService = employeeService;
            _creditRequestService = creditRequestService;
            _creditAccountService = creditAccountService;

            _currencies = currencyService.GetAllModels(new AllModelsQuery()).Value.ToArray();
            _creditTypes = creditTypeService.GetAllModels(new AllModelsQuery()).Value.ToArray();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RequestDetails(int id, string type)
        {
            ViewBag.ApproveActionName = type + "Approve";
            var request = _creditRequestService.GetModel(new ModelQuery {Id = id}).Value;
            var employee = GetEmployee();
            if (request.LatestEmployeeHandledBy != null && request.LatestEmployeeHandledBy.Id != employee.Id)
            {
                return RedirectToAction("Index");
            }
            _creditRequestService.AssignToEmployee(request, employee);
            return View(request);
        }
        
        [Authorize(Roles = "operator")]
        [HttpGet]
        public ActionResult Operator(OperatorCreditRequestsQuery query)
        {
            ViewBag.EmployeeType = "Operator";

            ViewBag.Currency =
                _currencies.Select(model => new SelectListItem { Value = model.Id.ToString(), Text = model.Name });
            ViewBag.CreditTypes =
                _creditTypes.Select(model => new SelectListItem { Value = model.Id.ToString(), Text = model.Name });

            var employee = GetEmployee();
            query.EmployeeId = employee.Id;
            var requests =
                _employeeService.GetOperatorCreditRequests(query).Value;
            requests = FilterAssignedRequests(requests);
            return View("CurrentRequests", requests);
        }

        [Authorize(Roles = "operator")]
        [HttpPost]
        public ActionResult OperatorApprove(OperatorApproveCommand command)
        {
            var employee = GetEmployee();
            command.EmployeeId = employee.Id;
            _employeeService.OperatorApproveCommand(command);
            var request = GetRequest(command);
            _creditRequestService.UnassignEmployee(request);
            return RedirectToAction("Operator");
        }

        [Authorize(Roles = "security")]
        [HttpGet]
        public ActionResult Security(SecurityCreditRequestsQuery query)
        {
            ViewBag.EmployeeType = "Security";

            ViewBag.Currency =
                _currencies.Select(model => new SelectListItem { Value = model.Id.ToString(), Text = model.Name });
            ViewBag.CreditTypes =
                _creditTypes.Select(model => new SelectListItem { Value = model.Id.ToString(), Text = model.Name });

            var employee = GetEmployee();
            query.EmployeeId = employee.Id;
            var requests =
                _employeeService.GetSecurityCreditRequests(query).Value;
            requests = FilterAssignedRequests(requests);
            return View("CurrentRequests", requests);
        }

        [Authorize(Roles = "security")]
        [HttpPost]
        public ActionResult SecurityApprove(SecurityApproveCommand command)
        {
            var employee = GetEmployee();
            command.EmployeeId = employee.Id;
            _employeeService.SecurityApproveCommand(command);
            var request = GetRequest(command);
            _creditRequestService.UnassignEmployee(request);
            return RedirectToAction("Security");
        }

        [Authorize(Roles = "committee member")]
        [HttpGet]
        public ActionResult Committee(CommiteeCreditRequestsQuery query)
        {
            ViewBag.EmployeeType = "Committee";

            ViewBag.Currency =
                _currencies.Select(model => new SelectListItem { Value = model.Id.ToString(), Text = model.Name });
            ViewBag.CreditTypes =
                _creditTypes.Select(model => new SelectListItem { Value = model.Id.ToString(), Text = model.Name });

            var employee = GetEmployee();
            query.EmployeeId = employee.Id;
            var requests =
                _employeeService.GetCommiteeCreditRequests(query).Value;
            requests = FilterAssignedRequests(requests);
            return View("CurrentRequests", requests);
        }

        [Authorize(Roles = "committee member")]
        [HttpPost]
        public ActionResult CommitteeApprove(CommiteeApproveCommand command)
        {
            var employee = GetEmployee();
            command.EmployeeId = employee.Id;
            _employeeService.CommiteeApproveCommand(command);
            var request = GetRequest(command);
            _creditRequestService.UnassignEmployee(request);
            return RedirectToAction("Committee");
        }

        [Authorize(Roles = "department chief")]
        [HttpGet]
        public ActionResult Department(DepartmentCreditRequestsQuery query)
        {
            ViewBag.EmployeeType = "Department";

            ViewBag.Currency =
                _currencies.Select(model => new SelectListItem { Value = model.Id.ToString(), Text = model.Name });
            ViewBag.CreditTypes =
                _creditTypes.Select(model => new SelectListItem { Value = model.Id.ToString(), Text = model.Name });

            var employee = GetEmployee();
            query.EmployeeId = employee.Id;
            var requests =
                _employeeService.GetDepartmentCreditRequests(query).Value;
            requests = FilterAssignedRequests(requests);
            return View("CurrentRequests", requests);
        }

        [Authorize(Roles = "department chief")]
        [HttpPost]
        public ActionResult DepartmentApprove(DepartmentApproveCommand command)
        {
            var employee = GetEmployee();
            command.EmployeeId = employee.Id;
            _employeeService.DepartmentApproveCommand(command);
            var request = GetRequest(command);
            _creditRequestService.UnassignEmployee(request);
            return RedirectToAction("Department");
        }

        [Authorize(Roles = "operator")]
        [HttpGet]
        public ActionResult OperatorFinal(IEnumerable<CreditRequestViewModel> requests, string passportNumber)
        {
            if (requests == null)
            {
                requests = _employeeService.GetApprovedClientRequests(new ApprovedClientRequestsQuery
                {
                    PassportNumber = passportNumber,
                    EmployeeId = GetEmployee().Id
                }).Value;
            }
            ViewBag.passportNumber = passportNumber;
            return View(requests);
        }

        [Authorize(Roles = "operator")]
        [HttpPost]
        public ActionResult OperatorFinalApprove(int id, string passportNumber)
        {
            var requests = _employeeService.GetApprovedClientRequests(new ApprovedClientRequestsQuery
            {
                PassportNumber = passportNumber
            }).Value;

            _employeeService.OpenCreditAccount(new OpenCreditAccountCommand
            {
                CreditRequestId = id,
                EmployeeId = GetEmployee().Id
            });
            return RedirectToAction("OperatorFinal", new { requests, passportNumber });
        }

        [Authorize(Roles = "cashier")]
        [HttpGet]
        public ActionResult CashierGetCreditAccounts(string agreementNumber)
        {
            if (agreementNumber != null)
            {
                var res =  _creditAccountService.GetActualAccountStateDto(new ActualCreditAccountStateQuery()
                {
                    AgreementNumber = agreementNumber
                }).Value;
                ViewBag.agreementNumber = agreementNumber;
                return View(Mapper.Map<CreditAccountStateViewModel>(res));
            }
            ViewBag.agreementNumber = string.Empty;
            return View();
        }

        [Authorize(Roles = "cashier")]
        [HttpPost]
        public ActionResult CashierPaymentApprove(AddPaymentCommand command)
        {
            if (command == null) return RedirectToAction("CashierGetCreditAccounts");
            command.EmployeeId =
                _employeeService.GetEmployee(EmployeeQuery.WithUserId(int.Parse(User.Identity.GetUserId()))).Value.Id;
            _employeeService.AddPayment(command);
            var account = _creditAccountService.GetActualAccountStateDto(new ActualCreditAccountStateQuery()
            {
                Id = command.CreditAccountId
            });
            return RedirectToAction("CashierGetCreditAccounts", "Employee",
                new {agreementNumber = account.Value.CreditAccount.CreditAgreementNumber});
        }


        private EmployeeViewModel GetEmployee()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            var res = _employeeService.GetEmployee(EmployeeQuery.WithUserId(userId));
            return res.Value;
        }
        
        private CreditRequestViewModel GetRequest(ApproveCommand command)
        {
            var getRequestQuery = new ModelQuery()
            {
                Id = command.CreditRequestId
            };
            return _creditRequestService.GetModel(getRequestQuery).Value;
        }

        private IEnumerable<CreditRequestViewModel> FilterAssignedRequests(IEnumerable<CreditRequestViewModel> requests)
        {
            var employee = GetEmployee();
            return requests.Where(r => r.LatestEmployeeHandledBy == null || r.LatestEmployeeHandledBy.Id == employee.Id);
        }
    }
}