using System.Web.Mvc;
using BLL.Services.Common.Currency;
using BLL.Services.Common.Currency.ViewModels;
using Ninject.Infrastructure.Language;
using TOFI.TransferObjects.Model.Queries;

namespace TOFI.Web.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public AdminController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Currencies()
        {
            var currencies = _currencyService.GetAllModels(new AllModelsQuery()).Value.ToEnumerable();
            return View(currencies);
        }

        [HttpPost]
        public ActionResult AddCurrency(CurrencyViewModel newCurrency)
        {
            _currencyService.CreateModel(newCurrency);
            return RedirectToAction("Currencies");
        }

        public ActionResult RemoveCurrency(int id) // Yes, delete via GET request...
        {
            _currencyService.DeleteModel(id);
            return RedirectToAction("Currencies");
        }
    }
}