using DAL.Models.Common;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Common.DataObjects;
using DAL.Contexts;

namespace DAL.Repositories.Common.Currency
{
    public class CurrencyCommandRepository : ModelCommandRepository<CurrencyModel, CurrencyDto>, ICurrencyCommandRepository
    {
        public CurrencyCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}