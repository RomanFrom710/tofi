using BLL.Services.Actions.RequestAction.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Actions.RequestAction.DataObjects;

namespace BLL.Services.Actions.RequestAction
{
    public interface IRequestActionService : IModelService<RequestActionDto, RequestActionViewModel>
    {
    }
}