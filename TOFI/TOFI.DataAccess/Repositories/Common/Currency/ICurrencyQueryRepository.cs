using DAL.Repositories.Model;
using TOFI.TransferObjects.Common.Currency.DataObjects;

namespace DAL.Repositories.Common.Currency
{
    public interface ICurrencyQueryRepository: IModelQueryRepository<CurrencyDto>
    {
    }
}