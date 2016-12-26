using System.Web.Mvc;
using AutoMapper;
using BLL.Services.Client.ViewModels;
using BLL.Services.User;
using Microsoft.AspNet.Identity;
using TOFI.TransferObjects.User.Queries;

namespace TOFI.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUserService _userService;

        public ClientController(IUserService userService)
        {
            _userService = userService;
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
                user.Client = client;
                user.Id = int.Parse(User.Identity.GetUserId());
                _userService.UpdateModel(user);
                return RedirectToAction("Index");
            }

            return View(client);
        }

        public ActionResult Credit()
        {
            return View();
        }
    }
}
