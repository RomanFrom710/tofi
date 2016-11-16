using AutoMapper;
using BLL.Result;
using BLL.Services.Model.ViewModels;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Model.Commands;
using TOFI.TransferObjects.Model.DataObjects;
using TOFI.TransferObjects.Model.Queries;

namespace BLL.Services.Model
{
    public abstract class ModelService<TModelDto, TModelView> : Service, IModelService<TModelView>
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


        public ListQueryResult<TModelView> GetAllModels(AllModelsQuery query)
        {
            return RunListQuery(QueryRepository, query).MapTo<TModelView>();
        }

        public QueryResult<TModelView> GetModel(ModelQuery query)
        {
            return RunQuery(QueryRepository, query).MapTo<TModelView>();
        }

        public CommandResult CreateModel(TModelView viewModel)
        {
            return ExecuteCommand(CommandRepository,
                new CreateModelCommand<TModelDto> {ModelDto = Mapper.Map<TModelDto>(viewModel)});
        }

        public CommandResult UpdateModel(TModelView viewModel)
        {
            return ExecuteCommand(CommandRepository,
                new UpdateModelCommand<TModelDto> {ModelDto = Mapper.Map<TModelDto>(viewModel)});
        }

        public CommandResult DeleteModel(int id)
        {
            return ExecuteCommand(CommandRepository, new DeleteModelCommand {Id = id});
        }
    }
}