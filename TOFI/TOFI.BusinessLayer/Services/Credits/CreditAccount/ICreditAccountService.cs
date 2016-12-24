using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;

namespace BLL.Services.Credits.CreditAccount
{
    public interface ICreditAccountService : IModelService<CreditAccountDto, CreditAccountViewModel>
    {
    }
}