using System.Web.Mvc;
using AutoMapper;
using BLL.Services.Client;
using BLL.Services.Client.ViewModels;
using BLL.Services.User;
using Microsoft.AspNet.Identity;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.Model.Queries;
using TOFI.TransferObjects.User.Queries;

namespace TOFI.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IUserService _userService;

        public ClientController(IClientService clientService, IUserService userService)
        {
            _clientService = clientService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var user = _userService.GetUserDto(new UserQuery
            {
                Id = int.Parse(User.Identity.GetUserId())
            }).Value;

            var clientDto = user.Client;
            if (clientDto == null)
            {
                clientDto = new ClientDto {UserId = user.Id};
                _clientService.CreateModel(clientDto);
            }

            return View(Mapper.Map<ClientViewModel>(clientDto));
        }

        [HttpPost]
        public ActionResult Index(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                var clientDto = Mapper.Map<ClientDto>(client);
                clientDto.UserId = int.Parse(User.Identity.GetUserId());
                _clientService.UpdateModel(clientDto);
            }

            return View(client);
        }

        public ActionResult Credit()
        {
            return View();
        }
    }
}
