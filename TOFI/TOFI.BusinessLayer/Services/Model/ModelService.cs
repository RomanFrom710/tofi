using AutoMapper;
using BLL.Result;
using BLL.Services.Model.ViewModels;
using DAL.Repositories.Model;
using TOFI.TransferObjects.Model.Commands;
using TOFI.TransferObjects.Model.DataObjects;
using TOFI.TransferObjects.Model.Queries;

namespace BLL.Services.Model
{
    public abstract class ModelService<TModelDto, TModelView> : Service, IModelService<TModelDto, TModelView>
        where TModelDto : ModelDto where TModelView : ModelViewModel
    {
        private readonly IModelQueryRepository<TModelDto> _queryRepository;
        private readonly IModelCommandRepository<TModelDto> _commandRepository;


        protected ModelService(IModelQueryRepository<TModelDto> queryRepository,
            IModelCommandRepository<TModelDto> commandRepository)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
        }


        public ListQueryResult<TModelDto> GetAllModelDtos(AllModelsQuery query)
        {
            return RunListQuery(_queryRepository, query);
        }

        public ListQueryResult<TModelView> GetAllModels(AllModelsQuery query)
        {
            return RunListQuery(_queryRepository, query).MapTo<TModelView>();
        }

        public QueryResult<TModelDto> GetModelDto(ModelQuery query)
        {
            return RunQuery(_queryRepository, query);
        }

        public QueryResult<TModelView> GetModel(ModelQuery query)
        {
            return RunQuery(_queryRepository, query).MapTo<TModelView>();
        }

        public CommandResult CreateModel(TModelDto dto)
        {
            var command = new CreateModelCommand<TModelDto> { ModelDto = dto };
            var result = ExecuteCommand(_commandRepository, command);
            dto.Id = command.ModelDto.Id;

            return result;
        }

        public CommandResult CreateModel(TModelView viewModel)
        {
            return ExecuteCommand(_commandRepository,
                new CreateModelCommand<TModelDto> {ModelDto = Mapper.Map<TModelDto>(viewModel)});
        }

        public CommandResult UpdateModel(TModelDto dto)
        {
            return ExecuteCommand(_commandRepository, new UpdateModelCommand<TModelDto> {ModelDto = dto});
        }

        public CommandResult UpdateModel(TModelView viewModel)
        {
            return ExecuteCommand(_commandRepository,
                new UpdateModelCommand<TModelDto> {ModelDto = Mapper.Map<TModelDto>(viewModel)});
        }

        public CommandResult DeleteModel(int id)
        {
            return ExecuteCommand(_commandRepository, new DeleteModelCommand {Id = id});
        }
    }
}