using System.Linq;
using DAL.Repositories.Credits.CreditAccount;
using BLL.Services.Credits.CreditAccount;
using TOFI.TransferObjects.Model.Queries;
using DAL.Contexts;
using NLog;

namespace TOFI.AccountUpdater
{
    public class AccountUpdaterService
    {
        private readonly CreditAccountService _creditAccountService;
        private readonly Logger Logger;

        public AccountUpdaterService()
        {
            Logger = LogManager.GetCurrentClassLogger(); 
            var context = new TofiContext();
            var creditAccountService = new CreditAccountService(new CreditAccountQueryRepository(context), new CreditAccountCommandRepository(context));
            _creditAccountService = creditAccountService;
        }
        
        public void UpdateRemains()
        {
            Logger.Info(() => "UpdateRemains called");
            var query = new AllModelsQuery();
            var value = _creditAccountService.GetAllModelDtos(query).Value;
            var accounts = value.ToArray();
            foreach (var account in accounts)
            {
                account.RemainDebt.Value *= (decimal) (1 + account.InterestRate);
                _creditAccountService.UpdateModel(account);
            }
            
        }
    }
}
