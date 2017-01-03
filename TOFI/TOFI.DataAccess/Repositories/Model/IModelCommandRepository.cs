using TOFI.TransferObjects.Model.Commands;
using TOFI.TransferObjects.Model.DataObjects;

namespace DAL.Repositories.Model
{
    public interface IModelCommandRepository<TModelDto> : IRepository,
        ICommandRepository<CreateModelCommand<TModelDto>>,
        ICommandRepository<UpdateModelCommand<TModelDto>>,
        ICommandRepository<UpdateModelsCommand<TModelDto>>,
        ICommandRepository<DeleteModelCommand>
        where TModelDto : ModelDto
    {
         
    }
}