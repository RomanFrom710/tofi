using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Client.Queries;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;

namespace BLL.Services.Credits.BankCredits.CreditTypes
{
    public interface ICreditTypeService : IModelService<CreditTypeDto, CreditTypeViewModel>
    {
        decimal MinMonthPayment(SelectCreditTypesQuery query, CreditTypeViewModel creditType);

        decimal MaxMonthPayment(SelectCreditTypesQuery query, CreditTypeViewModel creditType);

        decimal GetAveragePayment(SelectCreditTypesQuery query, CreditTypeViewModel creditType);
    }
}