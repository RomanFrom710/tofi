using DAL.Repositories.Credits.CreditAccount;
using TOFI.TransferObjects.Model.Queries;
using DAL.Contexts;
using NLog;
using TOFI.TransferObjects.Model.Commands;
using TOFI.TransferObjects.Credits.CreditAccount.DataObjects;
using System.Linq;

namespace TOFI.AccountUpdater
{
    public class AccountUpdaterService
    {
        private readonly Logger Logger;
        private readonly CreditAccountQueryRepository _creditAccountQueryRepository;
        private readonly CreditAccountCommandRepository _creditAccountCommandRepository;

        public AccountUpdaterService()
        {
            Logger = LogManager.GetCurrentClassLogger(); 
            var context = new TofiContext();
            _creditAccountCommandRepository = new CreditAccountCommandRepository(context);
            _creditAccountQueryRepository = new CreditAccountQueryRepository(context);
        }
        
        public void UpdateRemains()
        {
            //Logger.Info("UpdateRemains called");
            //var query = new AllModelsQuery();
            //var accounts = _creditAccountQueryRepository.Handle(query);
            //foreach (var account in accounts)
            //{
            //    account.RemainDebt.Value *= (decimal) (1 + account.CreditType.InterestRate);
            //}
            //var updateModelsCommand = new UpdateModelsCommand<CreditAccountDto>()
            //{
            //    ModelsDto = accounts.ToList()
            //};
            //_creditAccountCommandRepository.Execute(updateModelsCommand);
        }
    }
}
