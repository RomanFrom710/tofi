using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;

namespace BLL.Services.Credits.BankCredits.CreditTypes
{
    public interface ICreditTypeService : IModelService<CreditTypeDto, CreditTypeViewModel>
    {
    }
}