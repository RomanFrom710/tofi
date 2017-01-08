using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.CreditAccount;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;

namespace BLL.Services.Credits.CreditAccount
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