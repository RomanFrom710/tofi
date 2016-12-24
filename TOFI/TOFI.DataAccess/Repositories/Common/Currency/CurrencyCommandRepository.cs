using DAL.Models.Common;
using DAL.Repositories.Model;
using DAL.Contexts;
using TOFI.TransferObjects.Common.Currency.DataObjects;

namespace DAL.Repositories.Common.Currency
{
    public class CurrencyCommandRepository : ModelCommandRepository<CurrencyModel, CurrencyDto>, ICurrencyCommandRepository
    {
        public CurrencyCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}