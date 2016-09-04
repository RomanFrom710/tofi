using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IModelRepository<TModel> : IRepository
        where TModel : IModel
    {
        TModel GetModel(int id);

        IEnumerable<TModel> GetAllModels();
    }
}