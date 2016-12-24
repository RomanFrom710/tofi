using BLL.Services.Common.Currency.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Common.Currency.DataObjects;

namespace BLL.Services.Common.Currency
{
    public interface ICurrencyService : IModelService<CurrencyDto, CurrencyViewModel>
    {
    }
}