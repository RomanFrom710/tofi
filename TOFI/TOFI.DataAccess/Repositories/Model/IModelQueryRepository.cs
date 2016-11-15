using TOFI.TransferObjects.Model.DataObjects;
using TOFI.TransferObjects.Model.Queries;

namespace DAL.Repositories.Model
{
    public interface IModelQueryRepository<TModelDto> : IRepository,
        IListQueryRepository<AllModelsQuery, TModelDto>,
        IQueryRepository<ModelQuery, TModelDto>
        where TModelDto : ModelDto
    {
    }
}