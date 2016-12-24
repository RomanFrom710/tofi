using BLL.Services.Credits.BankCredits.CreditRequirements.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.BankCredits.CreditRequirements;
using TOFI.TransferObjects.Credits.BankCredits.CreditRequirements.DataObjects;

namespace BLL.Services.Credits.BankCredits.CreditRequirements
{
    public class CreditRequirementService : ModelService<CreditRequirementDto, CreditRequirementViewModel>, ICreditRequirementService
    {
        private readonly ICreditRequirementQueryRepository _queryRepository;
        private readonly ICreditRequirementCommandRepository _commandRepository;


        public CreditRequirementService(ICreditRequirementQueryRepository queryRepository,
            ICreditRequirementCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}