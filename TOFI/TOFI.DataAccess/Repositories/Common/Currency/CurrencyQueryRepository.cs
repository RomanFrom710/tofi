using DAL.Models.Common;
using DAL.Repositories.Model;
using DAL.Contexts;
using TOFI.TransferObjects.Common.Currency.DataObjects;

namespace DAL.Repositories.Common.Currency
{
    public class CurrencyQueryRepository : ModelQueryRepository<CurrencyModel, CurrencyDto>, ICurrencyQueryRepository
    {
        public CurrencyQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}