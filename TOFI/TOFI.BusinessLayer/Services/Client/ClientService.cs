using System;
using BLL.Result;
using BLL.Services.Client.ViewModels;
using BLL.Services.Model;
using BLL.Services.User;
using DAL.Repositories.Client;
using TOFI.TransferObjects.Client.DataObjects;
using TOFI.TransferObjects.User.DataObjects;
using TOFI.TransferObjects.User.Queries;

namespace BLL.Services.Client
{
    public class ClientService : ModelService<ClientDto, ClientViewModel>, IClientService
    {
        private readonly IClientQueryRepository _queryRepository;
        private readonly IClientCommandRepository _commandRepository;
        private readonly IUserService _userService;


        public ClientService(IClientQueryRepository queryRepository, IClientCommandRepository commandRepository,
            IUserService userService) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _userService = userService;
        }


        public ValueResult<bool> CanAddCreditRequest(int userId)
        {
            var userRes = _userService.GetUserDto(new UserQuery {Id = userId});
            if (userRes.IsFailed)
            {
                return new ValueResult<bool>(false, false).From(userRes);
            }
            try
            {
                var msg = ValidateClient(userRes.Value);
                if (!string.IsNullOrEmpty(msg))
                {
                    return new ValueResult<bool>(false, true).Error(msg);
                }
                return new ValueResult<bool>(true, true);
            }
            catch (Exception ex)
            {
                return new ValueResult<bool>(false, false).Fatal($"Unhandled exception: {ex.Message}", ex);
            }
        }


        private string ValidateClient(UserDto user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName))
                return "First Name not filled";
            if (string.IsNullOrWhiteSpace(user.LastName))
                return "Last Name not filled";
            if (string.IsNullOrWhiteSpace(user.MiddleName))
                return "Middle Name not filled";
            if (user.Client == null)
                return "Client info not filled";
            if (string.IsNullOrWhiteSpace(user.Client.Address))
                return "Address not filled";
            if (string.IsNullOrWhiteSpace(user.Client.TelephoneNumber))
                return "Telephone Number not filled";
            if (string.IsNullOrWhiteSpace(user.Client.PassportNumber))
                return "Passport Number not filled";
            if (string.IsNullOrWhiteSpace(user.Client.PassportId))
                return "Passport Id not filled";
            if (string.IsNullOrWhiteSpace(user.Client.Authority))
                return "Authority not filled";
            var age = (int) Math.Floor((DateTime.Now.Date - user.Client.Birthday.Date).TotalDays/365);
            if (age < 18)
                return "You are too young to take credits.";
            if (age > 150)
                return "People normally don't live that long.";
            if (DateTime.Now.Date < user.Client.IssueDate)
                return "Your passport is from future. Sorry, but we can't accept it.";
            if (DateTime.Now.Date > user.Client.ExpirationDate)
                return "Your passport is outdated. Go get a new one.";
            return string.Empty;
        }
    }
}