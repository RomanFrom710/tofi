using System;
using System.Collections.Generic;

namespace DAL.Repositories.Model
{
    public interface IModelRepository<TModel> : IRepository
        where TModel : IModel
    {
        TModel GetModel(int id);

        IEnumerable<TModel> GetAllModels();

        TModel GetModel(Predicate<TModel> predicate);

        IEnumerable<TModel> GetModels(Predicate<TModel> predicate);
    }
}