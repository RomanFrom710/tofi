using BLL.Services.Credits.CreditAccountState.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.CreditAccountState;
using TOFI.TransferObjects.Credits.CreditAccountState.DataObjects;

namespace BLL.Services.Credits.CreditAccountState
{
    public class CreditAccountStateService : ModelService<CreditAccountStateDto, CreditAccountStateViewModel>, ICreditAccountStateService
    {
        private readonly ICreditAccountStateQueryRepository _queryRepository;
        private readonly ICreditAccountStateCommandRepository _commandRepository;


        public CreditAccountStateService(ICreditAccountStateQueryRepository queryRepository,
            ICreditAccountStateCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}