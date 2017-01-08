using BLL.Services.Credits.CreditAccountState.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Credits.CreditAccountState.DataObjects;

namespace BLL.Services.Credits.CreditAccountState
{
    public interface ICreditAccountStateService : IModelService<CreditAccountStateDto, CreditAccountStateViewModel>
    {
    }
}