using System.Data.Entity;
using DAL.Contexts;
using DAL.Models;

namespace DAL.Repositories
{
    public abstract class ModelRepository<TModel> : Repository where TModel : class, IModel
    {
        protected readonly DbSet<TModel> ModelsDao;


        protected ModelRepository(TofiContext context) : base(context)
        {
            ModelsDao = Context.Set<TModel>();
        }
    }
}