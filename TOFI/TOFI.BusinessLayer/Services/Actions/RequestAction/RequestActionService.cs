using BLL.Services.Actions.RequestAction.ViewModels;
using BLL.Services.Model;
using DAL.Repositories.Actions.RequestAction;
using TOFI.TransferObjects.Actions.RequestAction.DataObjects;

namespace BLL.Services.Actions.RequestAction
{
    public class RequestActionService : ModelService<RequestActionDto, RequestActionViewModel>, IRequestActionService
    {
        private readonly IRequestActionQueryRepository _queryRepository;
        private readonly IRequestActionCommandRepository _commandRepository;


        public RequestActionService(IRequestActionQueryRepository queryRepository, IRequestActionCommandRepository commandRepository)
            : base(queryRepository, commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }
    }
}