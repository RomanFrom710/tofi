using BLL.Services.Credits.CreditPayment.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Credits.CreditPayment;
using TOFI.TransferObjects.Credits.CreditPayment.DataObjects;

namespace BLL.Services.Credits.CreditPayment
{
    public class CreditPaymentService : ModelService<CreditPaymentDto, CreditPaymentViewModel>, ICreditPaymentService
    {
        private readonly ICreditPaymentQueryRepository _queryRepository;
        private readonly ICreditPaymentCommandRepository _commandRepository;


        public CreditPaymentService(ICreditPaymentQueryRepository queryRepository,
            ICreditPaymentCommandRepository commandRepository) : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}