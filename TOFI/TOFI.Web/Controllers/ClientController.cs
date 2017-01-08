using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.Services.Client;
using BLL.Services.Client.ViewModels;
using BLL.Services.Common.Currency;
using BLL.Services.Common.Currency.ViewModels;
using BLL.Services.Common.Price.ViewModels;
using BLL.Services.Credits.BankCredits.CreditConditions.ViewModels;
using BLL.Services.Credits.BankCredits.CreditRequirements.ViewModels;
using BLL.Services.Credits.BankCredits.CreditTypes;
using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Credits.CreditRequest;
using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.User;
using Microsoft.AspNet.Identity;
using TOFI.TransferObjects.Client.Queries;
using TOFI.TransferObjects.Credits.CreditRequest.Queries;
using TOFI.TransferObjects.Model.Queries;
using TOFI.TransferObjects.User.Queries;
using TOFI.Web.Infrastructure;

namespace TOFI.Web.Controllers
{
    [EmployeePasswordChange]
    [Authorize]
    public class ClientController : Controller
    {
        private readonly ICreditRequestService _creditRequestService;
        private readonly IClientService _clientService;
        private readonly IUserService _userService;

        private readonly IEnumerable<CreditTypeViewModel> _creditTypes;
        private readonly IEnumerable<CurrencyViewModel> _currencies;

        public ClientController(ICurrencyService currencyService,
                                IClientService clientService,
                                ICreditRequestService creditRequestService,
                                ICreditTypeService creditTypeService,
                                IUserService userService)
        {
            _clientService = clientService;
            _creditRequestService = creditRequestService;
            _userService = userService;

            _currencies = currencyService.GetAllModels(new AllModelsQuery()).Value.ToArray();
            _creditTypes = creditTypeService.GetAllModels(new AllModelsQuery()).Value.ToArray();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var client = GetClient();
            var validationResult = _clientService.CanAddCreditRequest(int.Parse(User.Identity.GetUserId()));
            if (!validationResult.Value)
            {
                ModelState.AddModelError(string.Empty, validationResult.Message);
            }
            return View(client);
        }

        [HttpPost]
        public ActionResult Index(ClientViewModel client)
        {
            var validationResult = _clientService.ValidateClientInfo(client);
            if (!validationResult.Value)
            {
                ViewBag.isValid = false;
                ModelState.AddModelError(string.Empty, validationResult.Message);
            }

            if (ModelState.IsValid)
            {
                _clientService.AddOrUpdateClient(client);
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
                _creditTypes.Select(model => new SelectListItem {Value = model.Id.ToString(), Text = model.Name});
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

            return View(newSuperPuperModel);
        }

        [HttpPost]
        public ActionResult AddCredit(CreditRequestViewModel credit)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Currency =
                    _currencies.Select(model => new SelectListItem {Value = model.Id.ToString(), Text = model.Name});
                ViewBag.CreditTypes =
                    _creditTypes.Select(model => new SelectListItem {Value = model.Id.ToString(), Text = model.Name});
                ViewBag.CreditTypesInfo = _creditTypes;
                return View(credit);
            }

            credit.Client = GetClient();
            credit.CreditSum.Currency = _currencies.First(cur => cur.Id == credit.CreditSum.Currency.Id);
            credit.CreditType = _creditTypes.First(typ => typ.Id == credit.CreditType.Id);

            var validationRes = _creditRequestService.ValidateCreditRequest(credit);
            if (!validationRes.Value)
            {
                ViewBag.Currency =
                    _currencies.Select(model => new SelectListItem {Value = model.Id.ToString(), Text = model.Name});
                ViewBag.CreditTypes =
                    _creditTypes.Select(model => new SelectListItem {Value = model.Id.ToString(), Text = model.Name});
                ViewBag.CreditTypesInfo = _creditTypes;
                ModelState.AddModelError("", validationRes.Message);
                return View(credit);
            }

            _creditRequestService.CreateModel(credit);

            return RedirectToAction("CreditRequests");
        }


        public ActionResult CreditRequests()
        {
            var client = GetClient();

            var requests =
                _creditRequestService.GetClientRequests(new ClientRequestsQuery {ClientId = client.Id}).Value.ToArray();

            return View(requests);
        }

        public ActionResult RemoveCreditRequest(int id) // Yes, it is removing via GET request, but who cares... todo: remove this project from GitHub
        {
            _creditRequestService.DeleteModel(id);

            return RedirectToAction("CreditRequests");
        }


        public ActionResult Credits()
        {
            var client = GetClient();
            
            // todo: pass credit accounts
            return View(new List<CreditAccountViewModel>());
        }


        private ClientViewModel GetClient()
        {
            var userId = int.Parse(User.Identity.GetUserId());
            var res = _clientService.GetClient(ClientQuery.WithUserId(userId));
            if (res.Value == null)
            {
                return new ClientViewModel {User = _userService.GetUser(UserQuery.WithId(userId)).Value};
            }
            return res.Value;
        }
    }
}