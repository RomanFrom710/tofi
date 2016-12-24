using DAL.Models.Common;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Common.DataObjects;
using DAL.Contexts;

namespace DAL.Repositories.Common.Price
{
    public class PriceQueryRepository : ModelQueryRepository<PriceModel, PriceDto>, IPriceQueryRepository
    {
        public PriceQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}