using BLL.Services.Credits.BankCredits.CreditConditions.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.BankCredits.CreditConditions;
using TOFI.TransferObjects.Credits.BankCredits.CreditConditions.DataObjects;

namespace BLL.Services.Credits.BankCredits.CreditConditions
{
    public class CreditConditionService : ModelService<CreditConditionDto, CreditConditionViewModel>, ICreditConditionService
    {
        private readonly ICreditConditionQueryRepository _queryRepository;
        private readonly ICreditConditionCommandRepository _commandRepository;


        public CreditConditionService(ICreditConditionQueryRepository queryRepository,
            ICreditConditionCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}