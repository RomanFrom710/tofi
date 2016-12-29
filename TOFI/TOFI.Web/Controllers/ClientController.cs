using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using BLL.Services.Client.ViewModels;
using BLL.Services.Common.Currency;
using BLL.Services.Common.Currency.ViewModels;
using BLL.Services.Common.Price.ViewModels;
using BLL.Services.Credits.BankCredits.CreditConditions.ViewModels;
using BLL.Services.Credits.BankCredits.CreditRequirements.ViewModels;
using BLL.Services.Credits.BankCredits.CreditTypes;
using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.User;
using Microsoft.AspNet.Identity;
using TOFI.TransferObjects.Model.Queries;
using TOFI.TransferObjects.User.Queries;

namespace TOFI.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUserService _userService;

        private readonly IEnumerable<CreditTypeViewModel> _creditTypes;
        private readonly IEnumerable<CurrencyViewModel> _currencies;

        public ClientController(IUserService userService,
            ICurrencyService currencyService, ICreditTypeService creditTypeService)
        {
            _userService = userService;

            _currencies = currencyService.GetAllModels(new AllModelsQuery()).Value.ToArray();
            _creditTypes = creditTypeService.GetAllModels(new AllModelsQuery()).Value.ToArray();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var user = _userService.GetUser(new UserQuery
            {
                Id = int.Parse(User.Identity.GetUserId())
            }).Value;
            var client = user.Client ?? new ClientViewModel();
            Mapper.Map(user, client);
            client.Id = user.Client?.Id ?? 0;
            return View(client);
        }

        [HttpPost]
        public ActionResult Index(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetUser(new UserQuery
                {
                    Id = int.Parse(User.Identity.GetUserId())
                }).Value;
                Mapper.Map(client, user);
                client.Id = user.Client?.Id ?? 0;
                user.Client = client;
                user.Id = int.Parse(User.Identity.GetUserId());
                _userService.UpdateModel(user);
                return RedirectToAction("Index");
            }

            return View(client);
        }

        [HttpGet]
        public ActionResult AddCredit()
        {
            ViewBag.Currency = 
                _currencies.Select(model => new SelectListItem {Value = model.Id.ToString(), Text = model.Name});
            ViewBag.CreditTypes =
                _creditTypes.Select(model => new SelectListItem {Value = model.Id.ToString(), Text = model.Description});
            ViewBag.CreditTypesInfo = _creditTypes;

            var newSuperPuperModel = new CreditRequestViewModel // I want to sleep...
            {
                CreditType = new CreditTypeViewModel
                {
                    CreditConditions = new List<CreditConditionViewModel>(),
                    CreditRequirements = new List<CreditRequirementViewModel>()
                },
                CreditSum = new PriceViewModel
                {
                    Currency = new CurrencyViewModel()
                }
            };

            return View("AddCredit", newSuperPuperModel);
        }

        [HttpPost]
        public ActionResult AddCredit(CreditRequestViewModel credit)
        {
            return View();
        }


        public ActionResult CreditRequests()
        {
            return View();
        }
    }
}
