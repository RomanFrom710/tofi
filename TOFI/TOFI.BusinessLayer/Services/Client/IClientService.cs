using BLL.Services.Client.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Client.DataObjects;

namespace BLL.Services.Client
{
    public interface IClientService : IModelService<ClientDto, ClientViewModel>
    {
    }
}