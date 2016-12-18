using System.Web.Mvc;
using BLL.Services.Client.ViewModels;

namespace TOFI.Web.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ClientViewModel client)
        {
            return View(client);
        }

        public ActionResult Credit()
        {
            return View();
        }
    }
}
