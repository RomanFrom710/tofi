using System.Data.Entity;
using DAL.Contexts;

namespace DAL.Repositories.Model
{
    public abstract class ModelRepository<TModel> : Repository where TModel : Models.Model
    {
        protected readonly DbSet<TModel> ModelsDao;


        protected ModelRepository(TofiContext context) : base(context)
        {
            ModelsDao = Context.Set<TModel>();
        }
    }
}