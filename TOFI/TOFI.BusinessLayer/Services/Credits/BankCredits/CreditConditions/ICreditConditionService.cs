using BLL.Services.Credits.BankCredits.CreditConditions.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects;

namespace BLL.Services.Credits.BankCredits.CreditConditions
{
    public interface ICreditConditionService : IModelService<CreditConditionDto, CreditConditionViewModel>
    {
    }
}