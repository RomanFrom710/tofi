using System.Web.Mvc;
using BLL.Services.Employee;
using BLL.Services.User;
using Microsoft.AspNet.Identity;
using TOFI.TransferObjects.Employee.Commands;
using TOFI.TransferObjects.Employee.Queries;
using TOFI.TransferObjects.User.Queries;

namespace TOFI.Web.Controllers
{
    [Authorize(Roles = "employee")]
    public class EmployeeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IUserService userService, IEmployeeService employeeService)
        {
            _userService = userService;
            _employeeService = employeeService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RequestDetails(int id)
        {
            return View();
        }

        [Authorize(Roles = "operator")]
        [HttpGet]
        public ActionResult Operator()
        {
            var employee = _userService.GetUser(new UserQuery
            {
                Id = int.Parse(User.Identity.GetUserId())
            }).Value.Employee;
            var requests =
                _employeeService.GetOperatorCreditRequests(new OperatorCreditRequestsQuery {EmployeeId = employee.Id}).Value;
            return View(requests);
        }

        [Authorize(Roles = "operator")]
        [HttpPost]
        public ActionResult OperatorApprove(OperatorApproveCommand command)
        {
            _employeeService.OperatorApproveCommand(new OperatorApproveCommand());
            return RedirectToAction("Operator");
        }
    }
}