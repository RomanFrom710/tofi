using System;
using System.Web.Mvc;
using BLL.Services.AccountUpdater;
using BLL.Services.Common.Currency;
using BLL.Services.Common.Currency.ViewModels;
using Ninject.Infrastructure.Language;
using TOFI.TransferObjects.Model.Queries;
using TOFI.Web.Infrastructure;

namespace TOFI.Web.Controllers
{
    [EmployeePasswordChange]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ICurrencyService _currencyService;
        private readonly IAccountUpdaterService _accountUpdaterService;


        public AdminController(ICurrencyService currencyService, IAccountUpdaterService accountUpdaterService)
        {
            _currencyService = currencyService;
            _accountUpdaterService = accountUpdaterService;
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

        [Authorize(Roles = "superuser")]
        [HttpGet]
        public ActionResult BankDay()
        {
            if (!TempData.ContainsKey("EndBankDayFailed"))
            {
                TempData["EndBankDayFailed"] = null;
                TempData["EndBankDayMessage"] = string.Empty;
            }
            return View();
        }

        [Authorize(Roles = "superuser")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EndBankDay()
        {
            var res = _accountUpdaterService.UpdateAccounts(DateTime.Now);
            TempData["EndBankDayFailed"] = (bool?) res.IsFailed;
            TempData["EndBankDayMessage"] = res.Message;
            return RedirectToAction("BankDay");
        }
    }
}