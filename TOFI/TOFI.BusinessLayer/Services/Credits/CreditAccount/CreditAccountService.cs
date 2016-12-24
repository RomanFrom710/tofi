using BLL.Services.Credits.CreditAccount.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.CreditAccount;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;

namespace BLL.Services.Credits.CreditAccount
{
    public class CreditAccountService : ModelService<CreditAccountDto, CreditAccountViewModel>, ICreditAccountService
    {
        private readonly ICreditAccountQueryRepository _queryRepository;
        private readonly ICreditAccountCommandRepository _commandRepository;


        public CreditAccountService(ICreditAccountQueryRepository queryRepository,
            ICreditAccountCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}