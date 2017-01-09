using BLL.Services.Actions.PaymentAction.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Actions.PaymentAction;
using TOFI.TransferObjects.Actions.PaymentAction.DataObjects;

namespace BLL.Services.Actions.PaymentAction
{
    public class PaymentActionService : ModelService<PaymentActionDto, PaymentActionViewModel>, IPaymentActionService
    {
        private readonly IPaymentActionQueryRepository _queryRepository;
        private readonly IPaymentActionCommandRepository _commandRepository;


        public PaymentActionService(IPaymentActionQueryRepository queryRepository, IPaymentActionCommandRepository commandRepository)
            : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}