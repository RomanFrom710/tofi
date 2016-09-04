using System.Linq;
using System.Collections.Generic;
using BLL.Interfaces;
using DAL.Interfaces;
using System;

namespace BLL.Services
{
    public abstract class BaseModelService<TModel, TViewModel, TRepository> : IModelService<TModel, TViewModel, TRepository>
        where TModel : IModel where TViewModel : IViewModel where TRepository : IModelRepository<TModel>
    {
        protected TRepository Repository;


        protected BaseModelService(TRepository repository)
        {
            Repository = repository;
        }


        protected abstract TViewModel MapModel(TModel model);


        public virtual IEnumerable<TViewModel> GetAllViewModels()
        {
            return Repository.GetAllModels().Select(m => MapModel(m));
        }

        public virtual TViewModel GetViewModel(int id)
        {
            return MapModel(Repository.GetModel(id));
        }

        public virtual TViewModel GetViewModel(Predicate<TModel> predicate)
        {
            return MapModel(Repository.GetModel(predicate));
        }

        public virtual IEnumerable<TViewModel> GetViewModels(Predicate<TModel> predicate)
        {
            return Repository.GetModels(predicate).Select(m => MapModel(m));
        }
    }
}