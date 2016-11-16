using BLL.Result;
using BLL.Services.Model.ViewModels;
using TOFI.TransferObjects.Model.Queries;

namespace BLL.Services.Model
{
    public interface IModelService<TModelView> : IService
        where TModelView : ModelViewModel
    {
        ListQueryResult<TModelView> GetAllModels(AllModelsQuery query);

        QueryResult<TModelView> GetModel(ModelQuery query);

        CommandResult CreateModel(TModelView viewModel);

        CommandResult UpdateModel(TModelView viewModel);

        CommandResult DeleteModel(int id);
    }
}