using DAL.Repositories.Model;
using TOFI.TransferObjects.Common.DataObjects;

namespace DAL.Repositories.Common.Price
{
    public interface IPriceCommandRepository: IModelCommandRepository<PriceDTO>
    {
    }
}