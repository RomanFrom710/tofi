using BLL.Services.Common.Currency.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Common.Currency;
using TOFI.TransferObjects.Common.Currency.DataObjects;

namespace BLL.Services.Common.Currency
{
    public class CurrencyService : ModelService<CurrencyDto, CurrencyViewModel>, ICurrencyService
    {
        private readonly ICurrencyQueryRepository _queryRepository;
        private readonly ICurrencyCommandRepository _commandRepository;


        public CurrencyService(ICurrencyQueryRepository queryRepository,
            ICurrencyCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}