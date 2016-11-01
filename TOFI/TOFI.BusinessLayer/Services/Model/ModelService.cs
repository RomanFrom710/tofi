using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Model;

namespace BLL.Services.Model
{
    public abstract class ModelService<TModel, TViewModel, TRepository> : IModelService<TModel, TViewModel, TRepository>
        where TModel : IModel where TViewModel : IViewModel where TRepository : IModelRepository<TModel>
    {
        protected TRepository Repository;


        protected ModelService(TRepository repository)
        {
            Repository = repository;
        }


        protected abstract TViewModel MapModel(TModel model);


        public virtual IEnumerable<TViewModel> GetAllViewModels()
        {
            return Repository.GetAllModels().Select(MapModel);
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
            return Repository.GetModels(predicate).Select(MapModel);
        }
    }
}