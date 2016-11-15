using BLL.Result;
using BLL.Services.Model.ViewModels;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Model.Commands;
using TOFI.TransferObjects.Model.DataObjects;
using TOFI.TransferObjects.Model.Queries;

namespace BLL.Services.Model
{
    public abstract class ModelService<TModelDto, TModelView> : Service, IModelService
        where TModelDto : ModelDto where TModelView : ModelViewModel
    {
        protected readonly IModelQueryRepository<TModelDto> QueryRepository;
        protected readonly IModelCommandRepository<TModelDto> CommandRepository;


        protected ModelService(IModelQueryRepository<TModelDto> queryRepository,
            IModelCommandRepository<TModelDto> commandRepository)
        {
            QueryRepository = queryRepository;
            CommandRepository = commandRepository;
        }


        public ListQueryResult<TModelDto> GetAllModels(AllModelsQuery query)
        {
            return RunListQuery(QueryRepository, query);
        }

        public QueryResult<TModelDto> GetModel(ModelQuery query)
        {
            return RunQuery(QueryRepository, query);
        }

        public CommandResult CreateModel(CreateModelCommand<TModelDto> command)
        {
            return ExecuteCommand(CommandRepository, command);
        }

        public CommandResult UpdateModel(UpdateModelCommand<TModelDto> command)
        {
            return ExecuteCommand(CommandRepository, command);
        }

        public CommandResult DeleteModel(DeleteModelCommand command)
        {
            return ExecuteCommand(CommandRepository, command);
        }
    }
}