using DAL.Contexts;
using DAL.Models.Actions;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Actions.RequestAction.DataObjects;

namespace DAL.Repositories.Actions.RequestAction
{
    public class RequestActionQueryRepository : ModelQueryRepository<RequestActionModel, RequestActionDto>, IRequestActionQueryRepository
    {
        public RequestActionQueryRepository(TofiContext context) : base(context)
        {
        }
    }
}