using DAL.Models.Common;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Common.DataObjects;
using DAL.Contexts;

namespace DAL.Repositories.Common.Price
{
    public class PriceCommandRepository : ModelCommandRepository<PriceModel, PriceDto>, IPriceCommandRepository
    {
        public PriceCommandRepository(TofiContext context) : base(context)
        {
        }
    }
}