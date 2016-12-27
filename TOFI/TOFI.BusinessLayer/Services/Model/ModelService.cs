using System.Threading.Tasks;
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


        public virtual ListQueryResult<TModelDto> GetAllModelDtos(AllModelsQuery query)
        {
            return RunListQuery(_queryRepository, query);
        }

        public virtual async Task<ListQueryResult<TModelDto>> GetAllModelDtosAsync(AllModelsQuery query)
        {
            return await RunListQueryAsync(_queryRepository, query);
        }

        public virtual ListQueryResult<TModelView> GetAllModels(AllModelsQuery query)
        {
            return RunListQuery(_queryRepository, query).MapTo<TModelView>();
        }

        public virtual async Task<ListQueryResult<TModelView>> GetAllModelsAsync(AllModelsQuery query)
        {
            return (await RunListQueryAsync(_queryRepository, query)).MapTo<TModelView>();
        }

        public virtual QueryResult<TModelDto> GetModelDto(ModelQuery query)
        {
            return RunQuery(_queryRepository, query);
        }

        public virtual async Task<QueryResult<TModelDto>> GetModelDtoAsync(ModelQuery query)
        {
            return await RunQueryAsync(_queryRepository, query);
        }

        public virtual QueryResult<TModelView> GetModel(ModelQuery query)
        {
            return RunQuery(_queryRepository, query).MapTo<TModelView>();
        }

        public virtual async Task<QueryResult<TModelView>> GetModelAsync(ModelQuery query)
        {
            return (await RunQueryAsync(_queryRepository, query)).MapTo<TModelView>();
        }

        public virtual CommandResult CreateModel(TModelDto dto)
        {
            return ExecuteCommand(_commandRepository, new CreateModelCommand<TModelDto> {ModelDto = dto});
        }

        public virtual async Task<CommandResult> CreateModelAsync(TModelDto dto)
        {
            return await ExecuteCommandAsync(_commandRepository, new CreateModelCommand<TModelDto> {ModelDto = dto});
        }

        public virtual CommandResult CreateModel(TModelView viewModel)
        {
            var command = new CreateModelCommand<TModelDto> {ModelDto = Mapper.Map<TModelDto>(viewModel)};
            var res = ExecuteCommand(_commandRepository, command);
            Mapper.Map(command.ModelDto, viewModel);
            return res;
        }

        public virtual async Task<CommandResult> CreateModelAsync(TModelView viewModel)
        {
            var command = new CreateModelCommand<TModelDto> {ModelDto = Mapper.Map<TModelDto>(viewModel)};
            var res = await ExecuteCommandAsync(_commandRepository, command);
            Mapper.Map(command.ModelDto, viewModel);
            return res;
        }

        public virtual CommandResult UpdateModel(TModelDto dto)
        {
            return ExecuteCommand(_commandRepository, new UpdateModelCommand<TModelDto> {ModelDto = dto});
        }

        public virtual async Task<CommandResult> UpdateModelAsync(TModelDto dto)
        {
            return await ExecuteCommandAsync(_commandRepository, new UpdateModelCommand<TModelDto> {ModelDto = dto});
        }

        public virtual CommandResult UpdateModel(TModelView viewModel)
        {
            var command = new UpdateModelCommand<TModelDto> {ModelDto = Mapper.Map<TModelDto>(viewModel)};
            var res = ExecuteCommand(_commandRepository, command);
            Mapper.Map(command.ModelDto, viewModel);
            return res;
        }

        public virtual async Task<CommandResult> UpdateModelAsync(TModelView viewModel)
        {
            var command = new UpdateModelCommand<TModelDto> {ModelDto = Mapper.Map<TModelDto>(viewModel)};
            var res = await ExecuteCommandAsync(_commandRepository, command);
            Mapper.Map(command.ModelDto, viewModel);
            return res;
        }

        public virtual CommandResult DeleteModel(int id)
        {
            return ExecuteCommand(_commandRepository, new DeleteModelCommand {Id = id});
        }

        public virtual async Task<CommandResult> DeleteModelAsync(int id)
        {
            return await ExecuteCommandAsync(_commandRepository, new DeleteModelCommand {Id = id});
        }
    }
}