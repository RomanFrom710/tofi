using System.Diagnostics;
using System.Web.Mvc;

namespace TOFI.Web.Controllers
{
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