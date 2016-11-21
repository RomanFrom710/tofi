using BLL.Services.Client.ViewModels;
using BLL.Services.User;
using TOFI.TransferObjects.Client.DataObjects;

namespace BLL.Services.Client
{
    public interface IClientService : IUserService<ClientDto, ClientViewModel>
    {
    }
}