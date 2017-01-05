using System.Threading.Tasks;
using System.Web.Mvc;
using BLL.Services.Credits.CreditRequest;
using BLL.Services.Employee;
using BLL.Services.Employee.ViewModels;
using BLL.Services.User;
using Microsoft.AspNet.Identity;
using TOFI.TransferObjects.Employee.Commands;
using TOFI.TransferObjects.Employee.Queries;
using TOFI.TransferObjects.Model.Queries;
using TOFI.TransferObjects.User.Queries;
using TOFI.Web.Infrastructure;

namespace TOFI.Web.Controllers
{
    [EmployeePasswordChange]
    [Authorize(Roles = "employee")]
    public class EmployeeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;
        private readonly ICreditRequestService _creditRequestService;

        public EmployeeController(IUserService userService,
                                  IEmployeeService employeeService,
                                  ICreditRequestService creditRequestService)
        {
            _userService = userService;
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
            var employee = _userService.GetUser(new UserQuery
            {
                Id = int.Parse(User.Identity.GetUserId())
            }).Value.Employee;
            return employee;
        }
    }
}