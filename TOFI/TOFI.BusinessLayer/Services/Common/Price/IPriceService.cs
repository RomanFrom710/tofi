using BLL.Services.Common.Price.ViewModels;
using BLL.Services.Model;
using TOFI.TransferObjects.Common.Price.DataObjects;

namespace BLL.Services.Common.Price
{
    public interface IPriceService : IModelService<PriceDto, PriceViewModel>
    {
    }
}