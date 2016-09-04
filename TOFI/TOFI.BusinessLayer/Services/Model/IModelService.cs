using System;
using System.Collections.Generic;
using DAL.Repositories;
using DAL.Repositories.Model;

namespace BLL.Services.Model
{
    public interface IModelService<TModel, TViewModel, TRepository> : IService
        where TModel : IModel where TViewModel : IViewModel where TRepository : IModelRepository<TModel>
    {
        TViewModel GetViewModel(int id);

        IEnumerable<TViewModel> GetAllViewModels();

        TViewModel GetViewModel(Predicate<TModel> predicate);

        IEnumerable<TViewModel> GetViewModels(Predicate<TModel> predicate);
    }
}