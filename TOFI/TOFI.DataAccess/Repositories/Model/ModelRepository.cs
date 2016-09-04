using System;
using System.Collections.Generic;

namespace DAL.Repositories.Model
{
    public class ModelRepository<TModel> : IModelRepository<TModel>
        where TModel : IModel
    {
        public TModel GetModel(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> GetAllModels()
        {
            throw new NotImplementedException();
        }

        public TModel GetModel(Predicate<TModel> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> GetModels(Predicate<TModel> predicate)
        {
            throw new NotImplementedException();
        }
    }
}