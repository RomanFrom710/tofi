using BLL.Services.Common.Price.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Common.Price;
using TOFI.TransferObjects.Common.Price.DataObjects;

namespace BLL.Services.Common.Price
{
    public class PriceService : ModelService<PriceDto, PriceViewModel>, IPriceService
    {
        private readonly IPriceQueryRepository _queryRepository;
        private readonly IPriceCommandRepository _commandRepository;


        public PriceService(IPriceQueryRepository queryRepository,
            IPriceCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}