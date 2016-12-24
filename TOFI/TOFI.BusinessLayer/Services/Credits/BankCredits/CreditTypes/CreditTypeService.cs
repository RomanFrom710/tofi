using BLL.Services.Credits.BankCredits.CreditTypes.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.BankCredits.CreditTypes;
using TOFI.TransferObjects.Credits.BankCredits.CreditTypes.DataObjects;

namespace BLL.Services.Credits.BankCredits.CreditTypes
{
    public class CreditTypeService : ModelService<CreditTypeDto, CreditTypeViewModel>, ICreditTypeService
    {
        private readonly ICreditTypeQueryRepository _queryRepository;
        private readonly ICreditTypeCommandRepository _commandRepository;


        public CreditTypeService(ICreditTypeQueryRepository queryRepository,
            ICreditTypeCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}