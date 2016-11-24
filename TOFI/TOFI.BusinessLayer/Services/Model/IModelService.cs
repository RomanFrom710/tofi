using BLL.Result;
using BLL.Services.Model.ViewModels;
using TOFI.TransferObjects.Model.DataObjects;
using TOFI.TransferObjects.Model.Queries;

namespace BLL.Services.Model
{
    public interface IModelService<TModelDto, TModelView> : IService
        where TModelDto : ModelDto where TModelView : ModelViewModel
    {
        ListQueryResult<TModelDto> GetAllModelDtos(AllModelsQuery query);

        ListQueryResult<TModelView> GetAllModels(AllModelsQuery query);

        QueryResult<TModelDto> GetModelDto(ModelQuery query);

        QueryResult<TModelView> GetModel(ModelQuery query);

        CommandResult CreateModel(TModelDto dto);

        CommandResult CreateModel(TModelView viewModel);

        CommandResult UpdateModel(TModelDto dto);

        CommandResult UpdateModel(TModelView viewModel);

        CommandResult DeleteModel(int id);
    }
}