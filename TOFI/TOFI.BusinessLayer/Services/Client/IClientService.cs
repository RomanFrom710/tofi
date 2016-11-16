using BLL.Services.Client.ViewModels;
using BLL.Services.User;

namespace BLL.Services.Client
{
    public interface IClientService : IUserService<ClientViewModel>
    {
    }
}