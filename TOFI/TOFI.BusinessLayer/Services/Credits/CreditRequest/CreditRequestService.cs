using BLL.Services.Credits.CreditRequest.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.CreditRequest;
using TOFI.TransferObjects.Credits.CreditRequest.DataObjects;

namespace BLL.Services.Credits.CreditRequest
{
    public class CreditRequestService : ModelService<CreditRequestDto, CreditRequestViewModel>, ICreditRequestService
    {
        private readonly ICreditRequestQueryRepository _queryRepository;
        private readonly ICreditRequestCommandRepository _commandRepository;


        public CreditRequestService(ICreditRequestQueryRepository queryRepository,
            ICreditRequestCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}