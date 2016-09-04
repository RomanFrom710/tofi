using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
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