using DAL.Models.Common;
using DAL.Repositories.Model;
using DAL.Contexts;
using TOFI.TransferObjects.Common.Price.DataObjects;

namespace DAL.Repositories.Common.Price
{
    public class PriceQueryRepository : ModelQueryRepository<PriceModel, PriceDto>, IPriceQueryRepository
    {
        public PriceQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}