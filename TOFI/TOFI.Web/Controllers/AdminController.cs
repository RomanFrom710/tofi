using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Services.AccountUpdater;
using BLL.Services.Common.Currency;
using BLL.Services.Common.Currency.ViewModels;
using BLL.Services.Credits.BankCredits.CreditConditions.ViewModels;
using BLL.Services.Credits.BankCredits.CreditRequirements.ViewModels;
using BLL.Services.Credits.BankCredits.CreditTypes;
using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using Ninject.Infrastructure.Language;
using TOFI.TransferObjects.Model.Queries;
using TOFI.Web.Infrastructure;
using WebGrease.Css.Extensions;

namespace TOFI.Web.Controllers
{
    [EmployeePasswordChange]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly ICurrencyService _currencyService;
        private readonly ICreditTypeService _creditTypeService;
        private readonly IAccountUpdaterService _accountUpdaterService;


        public AdminController(ICurrencyService currencyService,
                               ICreditTypeService creditTypeService,
                               IAccountUpdaterService accountUpdaterService)
        {
            _currencyService = currencyService;
            _accountUpdaterService = accountUpdaterService;
            _creditTypeService = creditTypeService;
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

        public ActionResult CreditTypes(bool? showArchived)
        {
            if (showArchived == null) showArchived = false;
            var credits = _creditTypeService.GetAllModels(new AllModelsQuery()).Value;
            ViewBag.showArchived = showArchived;
            if (showArchived.Value) return View(credits);
            return View(credits.Where(c => !c.IsArchived));
        }

        [HttpGet]
        public ActionResult CreditAdd(int reqNum = 1, int condNum = 1)
        {
            var newCredit = new CreditTypeViewModel
            {
                CreditRequirements = new List<CreditRequirementViewModel>(new CreditRequirementViewModel[reqNum]),
                CreditConditions = new List<CreditConditionViewModel>(new CreditConditionViewModel[condNum])
            };
            ViewBag.Currency = _currencyService
                .GetAllModels(new AllModelsQuery()).Value
                .Select(model => new SelectListItem { Value = model.Id.ToString(), Text = model.Name });
            return View(newCredit);
        }

        [HttpPost]
        public ActionResult CreditAdd(CreditTypeViewModel creditType)
        {
            foreach (var cond in creditType.CreditConditions)
            {
                cond.MaxCreditSum.Currency.Id = cond.MinCreditSum.Currency.Id;
            }
            if (!_creditTypeService.ValidateCredit(creditType).Value)
            {
                ViewBag.Currency = _currencyService
                .GetAllModels(new AllModelsQuery()).Value
                .Select(model => new SelectListItem { Value = model.Id.ToString(), Text = model.Name });
                ModelState.AddModelError("", "Проверьте правильность введенных данных");
                return View(creditType);
            }
            _creditTypeService.CreateModel(creditType);
            return RedirectToAction("CreditTypes");
        }

        [HttpPost]
        public ActionResult CreditMoveToArchive(int id, bool showArchived=false)
        {
            var creditType = _creditTypeService.GetModel(new ModelQuery {Id = id}).Value;
            creditType.IsArchived = !creditType.IsArchived;
            _creditTypeService.UpdateModel(creditType);
            return RedirectToAction("CreditTypes", new { showArchived = showArchived});
        }

        public ActionResult CreditFullDescription(int typeId)
        {
            var credit = _creditTypeService.GetModel(new ModelQuery {Id = typeId}).Value;
            return View(credit);
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