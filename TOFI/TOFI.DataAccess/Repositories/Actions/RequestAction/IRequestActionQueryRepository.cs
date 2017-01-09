using DAL.Repositories.Model;
using TOFI.TransferObjects.Actions.RequestAction.DataObjects;

namespace DAL.Repositories.Actions.RequestAction
{
    public interface IRequestActionQueryRepository : IModelQueryRepository<RequestActionDto>
    {
    }
}