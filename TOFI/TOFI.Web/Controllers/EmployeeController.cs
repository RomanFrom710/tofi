using System.Collections.Generic;
using System.Web.Mvc;
using BLL.Services.Credits.CreditRequest;
using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.Employee;
using BLL.Services.Employee.ViewModels;
using Microsoft.AspNet.Identity;
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

        public EmployeeController(IEmployeeService employeeService,
                                  ICreditRequestService creditRequestService)
        {
            _employeeService = employeeService;
            _creditRequestService = creditRequestService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RequestDetails(int id, string type)
        {
            ViewBag.ApproveActionName = type + "Approve";
            var request = _creditRequestService.GetModel(new ModelQuery {Id = id}).Value;
            return View(request);
        }

        [Authorize(Roles = "operator")]
        [HttpGet]
        public ActionResult Operator()
        {
            ViewBag.EmployeeType = "Operator";

            var employee = GetEmployee();
            var requests =
                _employeeService.GetOperatorCreditRequests(new OperatorCreditRequestsQuery {EmployeeId = employee.Id}).Value;
            return View("CurrentRequests", requests);
        }

        [Authorize(Roles = "operator")]
        [HttpPost]
        public ActionResult OperatorApprove(OperatorApproveCommand command)
        {
            var employee = GetEmployee();
            command.EmployeeId = employee.Id;
            _employeeService.OperatorApproveCommand(command);
            return RedirectToAction("Operator");
        }

        [Authorize(Roles = "security")]
        [HttpGet]
        public ActionResult Security()
        {
            ViewBag.EmployeeType = "Security";

            var employee = GetEmployee();
            var requests =
                _employeeService.GetSecurityCreditRequests(new SecurityCreditRequestsQuery { EmployeeId = employee.Id }).Value;
            return View("CurrentRequests", requests);
        }

        [Authorize(Roles = "security")]
        [HttpPost]
        public ActionResult SecurityApprove(SecurityApproveCommand command)
        {
            var employee = GetEmployee();
            command.EmployeeId = employee.Id;
            _employeeService.SecurityApproveCommand(command);
            return RedirectToAction("Security");
        }

        [Authorize(Roles = "committee member")]
        [HttpGet]
        public ActionResult Committee()
        {
            ViewBag.EmployeeType = "Committee";

            var employee = GetEmployee();
            var requests =
                _employeeService.GetCommiteeCreditRequests(new CommiteeCreditRequestsQuery { EmployeeId = employee.Id }).Value;
            return View("CurrentRequests", requests);
        }

        [Authorize(Roles = "committee member")]
        [HttpPost]
        public ActionResult CommitteeApprove(CommiteeApproveCommand command)
        {
            var employee = GetEmployee();
            command.EmployeeId = employee.Id;
            _employeeService.CommiteeApproveCommand(command);
            return RedirectToAction("Committee");
        }

        [Authorize(Roles = "department chief")]
        [HttpGet]
        public ActionResult Department()
        {
            ViewBag.EmployeeType = "Department";

            var employee = GetEmployee();
            var requests =
                _employeeService.GetDepartmentCreditRequests(new DepartmentCreditRequestsQuery { EmployeeId = employee.Id }).Value;
            return View("CurrentRequests", requests);
        }

        [Authorize(Roles = "department chief")]
        [HttpPost]
        public ActionResult DepartmentApprove(DepartmentApproveCommand command)
        {
            var employee = GetEmployee();
            command.EmployeeId = employee.Id;
            _employeeService.DepartmentApproveCommand(command);
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

        private EmployeeViewModel GetEmployee()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            var res = _employeeService.GetEmployee(EmployeeQuery.WithUserId(userId));
            return res.Value;
        }
    }
}