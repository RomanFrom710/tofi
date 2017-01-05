using System.Diagnostics;
using System.Web.Mvc;
using TOFI.Web.Infrastructure;

namespace TOFI.Web.Controllers
{
    [EmployeePasswordChange]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Trace.TraceInformation("Main view");
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}