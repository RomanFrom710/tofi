using System.Web.Mvc;
using BLL.Services.Credits.CreditRequest;
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
            var employee = GetEmployee();
            var requests =
                _employeeService.GetOperatorCreditRequests(new OperatorCreditRequestsQuery {EmployeeId = employee.Id}).Value;
            return View(requests);
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

        private EmployeeViewModel GetEmployee()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            var res = _employeeService.GetEmployee(EmployeeQuery.WithUserId(userId));
            return res.Value;
        }
    }
}