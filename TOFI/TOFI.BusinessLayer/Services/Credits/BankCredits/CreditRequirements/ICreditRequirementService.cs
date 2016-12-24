using BLL.Services.Credits.BankCredits.CreditRequirements.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Credits.BankCredits.CreditRequirements.DataObjects;

namespace BLL.Services.Credits.BankCredits.CreditRequirements
{
    public interface ICreditRequirementService : IModelService<CreditRequirementDto, CreditRequirementViewModel>
    {
    }
}